using System;
using Battleship.API.Core.Contracts.Services;
using Battleship.API.Core.Contracts.UnitsOfWork;
using Battleship.API.Core.Enums;
using Battleship.API.Core.Exceptions;
using Battleship.API.Core.Models.Domain;
using Battleship.API.Core.Models.DTOs.Challenges;

namespace Battleship.API.Core.Services;

public class ChallengeService : IChallengeService
{
    private readonly IUnitOfWork _unitOfWork;

    public ChallengeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ChallengeDTO>> GetAllAsync(ChallengesInputDTO challengesInput)
    {
        if (challengesInput.Status != null && !Enum.IsDefined(typeof(ChallengeStatus), challengesInput.Status))
        {
            throw new AppArgumentException("Invalid status");
        }

        throw new NotImplementedException();
    }

    public async Task<NewChallengeResultDTO> NewAsync(int challengerId, NewChallengeInputDTO newChallengeInput)
    {
        var challengee = await _unitOfWork.Users.GetByUsernameAsync(newChallengeInput.Username);

        if (challengee == null)
        {
            throw new AppArgumentException("Invalid challengee");
        }

        var challenge = new Challenge
        {
            ChallengerId = challengerId,
            ChallengeeId = challengee.UserId,
            Status = 1
        };

        _unitOfWork.Challenges.Add(challenge);

        await _unitOfWork.CompleteAsync();

        return new NewChallengeResultDTO
        {
            ChallengeId = challenge.ChallengeId
        };
    }
}
