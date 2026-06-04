using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.MobileSuit;

namespace ServerInfinite.Persistence.Configurations.Cards.MobileSuit;

public class MobileSuitUsageConfigurations : IEntityTypeConfiguration<MobileSuitUsage>
{
    public void Configure(EntityTypeBuilder<MobileSuitUsage> builder)
    {
        builder.HasKey(x => x.Id);
    }
}