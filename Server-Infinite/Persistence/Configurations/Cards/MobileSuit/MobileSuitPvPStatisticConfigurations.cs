using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.MobileSuit;

namespace ServerInfinite.Persistence.Configurations.Cards.MobileSuit;

public class MobileSuitPvPStatisticConfigurations : IEntityTypeConfiguration<MobileSuitPvPStatistic>
{
    public void Configure(EntityTypeBuilder<MobileSuitPvPStatistic> builder)
    {
        builder.HasKey(x => x.Id);
    }
}