using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle;

public class PlayerLevelConfigurations : IEntityTypeConfiguration<PlayerLevel>
{
    public void Configure(EntityTypeBuilder<PlayerLevel> builder)
    {
        builder.HasKey(x => x.Id);
    }
}