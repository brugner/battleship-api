using System;

namespace Battleship.API.Core.Models.Domain;

public class Challenge
{
    public int ChallengeId { get; set; }
    public int ChallengerId { get; set; }
    public int ChallengeeId { get; set; }
    public int Status { get; set; }
}
