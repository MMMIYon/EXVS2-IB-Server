using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Triad.Ranking;

namespace ServerInfinite.Persistence.Configurations.Cards.Triad.Ranking;

public class TriadWantedCountConfigurations : IEntityTypeConfiguration<TriadWantedDefeatedCount>
{
    public void Configure(EntityTypeBuilder<TriadWantedDefeatedCount> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.CardId, x.Year, x.Month })
            .IsUnique();
    }
}