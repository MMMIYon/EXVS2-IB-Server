using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.MobileSuit;
using ServerInfinite.Models.Cards.Titles.MobileSuit;

namespace ServerInfinite.Persistence.Configurations.Cards.MobileSuit;

public class FavouriteMobileSuitConfigurations : IEntityTypeConfiguration<FavouriteMobileSuit>
{
    public void Configure(EntityTypeBuilder<FavouriteMobileSuit> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(e => e.MobileSuitDefaultTitle)
            .WithOne(e => e.FavouriteMobileSuit)
            .HasForeignKey<MobileSuitDefaultTitle>(e => e.FavouriteMobileSuitId)
            .IsRequired();
        
        builder.HasOne(e => e.MobileSuitClassMatchTitle)
            .WithOne(e => e.FavouriteMobileSuit)
            .HasForeignKey<MobileSuitClassMatchTitle>(e => e.FavouriteMobileSuitId)
            .IsRequired();
        
        builder.HasOne(e => e.MobileSuitTriadTitle)
            .WithOne(e => e.FavouriteMobileSuit)
            .HasForeignKey<MobileSuitTriadTitle>(e => e.FavouriteMobileSuitId)
            .IsRequired();
    }
}