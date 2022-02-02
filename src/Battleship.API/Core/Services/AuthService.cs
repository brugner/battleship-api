using Battleship.API.Core.Contracts.Repositories;
using Battleship.API.Core.Contracts.Services;
using Battleship.API.Core.Contracts.UnitsOfWork;
using Battleship.API.Core.Exceptions;
using Battleship.API.Core.Models.Domain;
using Battleship.API.Core.Models.DTOs.Auth;
using Battleship.API.Core.Settings;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Battleship.API.Core.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHashService _hashService;
    private readonly JwtSettings _jwtSettings;

    public AuthService(IUnitOfWork unitOfWork, IHashService hashService, IOptions<JwtSettings> jwtSettings)
    {
        _unitOfWork = unitOfWork;
        _hashService = hashService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<SignUpResultDTO> SignUpAsync(SignUpInputDTO signUpInput)
    {
        if (!signUpInput.Password.Equals(signUpInput.ConfirmPassword))
        {
            throw new AppArgumentException("Passwords don't match");
        }

        if (await _unitOfWork.Users.ExistsAsync(signUpInput.Username))
        {
            throw new AppArgumentException("Username already exists");
        }

        var user = new User
        {
            Username = signUpInput.Username.ToLower(),
            PasswordHash = _hashService.HashPassword(signUpInput.Password)
        };

        _unitOfWork.Users.Add(user);
        await _unitOfWork.CompleteAsync();

        return new SignUpResultDTO
        {
            Username = signUpInput.Username
        };
    }

    public async Task<SignInResultDTO> SignInAsync(SignInInputDTO signInInput)
    {
        var user = await _unitOfWork.Users.GetByUsernameAsync(signInInput.Username);

        if (user == null)
        {
            throw new AppArgumentException("Invalid username or password");
        }

        if (!_hashService.ValidatePassword(signInInput.Password, user.PasswordHash))
        {
            throw new AppArgumentException("Invalid username or password");
        }

        return new SignInResultDTO
        {
            UserId = user.UserId,
            Username = user.Username,
            Token = GenerateJwtToken(user)
        };
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}