using System;
using Battleship.API.Core.Models.DTOs.Challenges;

namespace Battleship.API.Core.Contracts.Services;

public interface IChallengeService
{
    Task<NewChallengeResultDTO> NewAsync(int challengerId, NewChallengeInputDTO newChallengeInput);
    Task<IEnumerable<ChallengeDTO>> GetAllAsync(ChallengesInputDTO challengesInput);
}
