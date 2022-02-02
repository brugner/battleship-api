using Battleship.API.Core.Contracts.Repositories;

namespace Battleship.API.Core.Contracts.UnitsOfWork;

public interface IUnitOfWork
{
    IUsersRepository Users { get; }
    IChallengesRepository Challenges { get; }
    Task<int> CompleteAsync();
}