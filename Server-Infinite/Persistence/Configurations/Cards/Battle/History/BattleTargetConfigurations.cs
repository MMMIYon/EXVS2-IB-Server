using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle.History;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle.History;

public class BattleTargetConfigurations : IEntityTypeConfiguration<BattleTarget>
{
    public void Configure(EntityTypeBuilder<BattleTarget> builder)
    {
        builder.HasKey(x => x.Id);
    }
}