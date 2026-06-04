using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle.History;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle.History;

public class PreBattleHistoryConfigurations : IEntityTypeConfiguration<PreBattleHistory>
{
    public void Configure(EntityTypeBuilder<PreBattleHistory> builder)
    {
        builder.HasKey(x => x.Id);
    }
}