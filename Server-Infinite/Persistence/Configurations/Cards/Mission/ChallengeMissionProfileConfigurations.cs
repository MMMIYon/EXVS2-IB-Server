using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Mission;

namespace ServerInfinite.Persistence.Configurations.Cards.Mission;

public class ChallengeMissionProfileConfigurations : IEntityTypeConfiguration<ChallengeMissionProfile>
{
    public void Configure(EntityTypeBuilder<ChallengeMissionProfile> builder)
    {
        builder.HasKey(x => x.Id);
    }
}