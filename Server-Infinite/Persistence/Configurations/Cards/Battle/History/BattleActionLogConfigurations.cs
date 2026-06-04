using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle.History;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle.History;

public class BattleActionLogConfigurations : IEntityTypeConfiguration<BattleActionLog>
{
    public void Configure(EntityTypeBuilder<BattleActionLog> builder)
    {
        builder.HasKey(x => x.Id);
    }
}