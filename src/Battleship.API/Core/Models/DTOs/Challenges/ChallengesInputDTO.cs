using System;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Core.Models.DTOs.Challenges;

public class ChallengesInputDTO
{
    [FromQuery]
    public int? Status { get; set; }
}

