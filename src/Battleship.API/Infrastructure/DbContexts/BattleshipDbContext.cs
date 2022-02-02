using Battleship.API.Core.Models.Domain;
using Battleship.API.Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Battleship.API.Infrastructure.DbContexts;

public class BattleshipDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Challenge> Challenges { get; set; } = default!;

    public BattleshipDbContext(DbContextOptions<BattleshipDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ChallengeEntityConfiguration());
    }
}