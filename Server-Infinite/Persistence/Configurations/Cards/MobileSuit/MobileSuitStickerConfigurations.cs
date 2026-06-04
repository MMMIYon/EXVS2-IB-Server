using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.MobileSuit;

namespace ServerInfinite.Persistence.Configurations.Cards.MobileSuit;

public class MobileSuitStickerConfigurations : IEntityTypeConfiguration<MobileSuitSticker>
{
    public void Configure(EntityTypeBuilder<MobileSuitSticker> builder)
    {
        builder.HasKey(x => x.StickerId);
    }
}