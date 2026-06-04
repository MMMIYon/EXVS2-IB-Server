using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle;

public class PlayerBattleStatisticConfigurations : IEntityTypeConfiguration<PlayerBattleStatistic>
{
    public void Configure(EntityTypeBuilder<PlayerBattleStatistic> builder)
    {
        builder.HasKey(x => x.Id);
    }
}