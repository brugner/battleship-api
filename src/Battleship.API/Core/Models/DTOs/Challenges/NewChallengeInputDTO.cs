using System;
using System.ComponentModel.DataAnnotations;

namespace Battleship.API.Core.Models.DTOs.Challenges;

public class NewChallengeInputDTO
{
    [Required, MinLength(3), MaxLength(50)]
    public string Username { get; init; } = default!;
}
