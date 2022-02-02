using Battleship.API.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battleship.API.Infrastructure.EntitiesConfiguration;

public class ChallengeEntityConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.Property(x => x.ChallengerId).IsRequired();
        builder.Property(x => x.ChallengeeId).IsRequired();
        builder.Property(x => x.Status).IsRequired();
    }
}