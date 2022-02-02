using Battleship.API.Core.Contracts.Repositories;
using Battleship.API.Core.Contracts.UnitsOfWork;
using Battleship.API.Infrastructure.DbContexts;

namespace Battleship.API.Infrastructure.UnitsOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BattleshipDbContext _dbContext;

    public IUsersRepository Users { get; private set; }
    public IChallengesRepository Challenges { get; private set; }

    public UnitOfWork(
        BattleshipDbContext context,
        IUsersRepository users,
        IChallengesRepository challenges)
    {
        _dbContext = context;
        Users = users;
        Challenges = challenges;
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}