using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle.History;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle.History;

public class BattleAllyConfigurations : IEntityTypeConfiguration<BattleAlly>
{
    public void Configure(EntityTypeBuilder<BattleAlly> builder)
    {
        builder.HasKey(x => x.Id);
    }
}