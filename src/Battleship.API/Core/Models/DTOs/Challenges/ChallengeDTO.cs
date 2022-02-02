using System;

namespace Battleship.API.Core.Models.DTOs.Challenges;

public class ChallengeDTO
{
    public int ChallengeId { get; set; }
    public int ChallengerId { get; set; }
    public string Challenger { get; set; } = default!;
    public int ChallengeeId { get; set; }
    public string Challengee { get; set; } = default!;
    public int Status { get; set; } = default!;
}

