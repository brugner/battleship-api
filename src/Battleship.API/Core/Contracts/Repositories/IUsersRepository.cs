using Battleship.API.Core.Models.Domain;

namespace Battleship.API.Core.Contracts.Repositories;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<bool> ExistsAsync(string username);
    Task<User?> GetByUsernameAsync(string username);
}