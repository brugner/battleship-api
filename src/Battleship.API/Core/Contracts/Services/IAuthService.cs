using Battleship.API.Core.Models.DTOs.Auth;

namespace Battleship.API.Core.Contracts.Services;

public interface IAuthService
{
    Task<SignUpResultDTO> SignUpAsync(SignUpInputDTO signUpInput);
    Task<SignInResultDTO> SignInAsync(SignInInputDTO signInInput);
}