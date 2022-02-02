namespace Battleship.API.Core.Models.DTOs.Auth;

public class SignInResultDTO
{
    public int UserId { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Token { get; set; } = default!;
}