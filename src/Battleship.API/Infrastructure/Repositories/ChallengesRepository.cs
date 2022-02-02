using Battleship.API.Infrastructure.DbContexts;
using Battleship.API.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Battleship.API.Core.Models.Domain;

namespace Battleship.API.Infrastructure.Repositories;

public class ChallengesRepository : GenericRepository<Challenge>, IChallengesRepository
{
    public ChallengesRepository(BattleshipDbContext dbContext) : base(dbContext)
    {

    }
}