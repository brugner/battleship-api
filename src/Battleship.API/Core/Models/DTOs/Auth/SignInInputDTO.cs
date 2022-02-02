using System.ComponentModel.DataAnnotations;

namespace Battleship.API.Core.Models.DTOs.Auth;

public class SignInInputDTO
{
    [Required, MinLength(3), MaxLength(50)]
    public string Username { get; init; } = default!;

    [Required, MinLength(6), MaxLength(50)]
    public string Password { get; init; } = default!;
}