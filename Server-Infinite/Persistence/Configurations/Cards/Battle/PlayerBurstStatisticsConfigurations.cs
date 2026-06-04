using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle;

public class PlayerBurstStatisticsConfiguration : IEntityTypeConfiguration<PlayerBurstStatistics>
{
    public void Configure(EntityTypeBuilder<PlayerBurstStatistics> builder)
    {
        builder.HasKey(x => x.Id);
    }
}