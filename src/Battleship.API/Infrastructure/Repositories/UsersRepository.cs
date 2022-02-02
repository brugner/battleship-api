using Battleship.API.Infrastructure.DbContexts;
using Battleship.API.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Battleship.API.Core.Models.Domain;

namespace Battleship.API.Infrastructure.Repositories;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(BattleshipDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<bool> ExistsAsync(string username)
    {
        return await DbContext.Users.FirstOrDefaultAsync(x => x.Username == username.ToLower()) != null;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await DbContext.Users.FirstOrDefaultAsync(x => x.Username == username.ToLower());
    }
}