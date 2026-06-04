using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle.History;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle.History;

public class BattleSelfConfigurations : IEntityTypeConfiguration<BattleSelf>
{
    public void Configure(EntityTypeBuilder<BattleSelf> builder)
    {
        builder.HasKey(x => x.Id);
    }
}