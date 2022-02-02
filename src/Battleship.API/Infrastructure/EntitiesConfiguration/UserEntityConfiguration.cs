using Battleship.API.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battleship.API.Infrastructure.EntitiesConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Username).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(x => x.PasswordHash).IsRequired();
    }
}