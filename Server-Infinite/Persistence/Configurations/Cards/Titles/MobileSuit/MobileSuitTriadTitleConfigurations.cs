using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Titles.MobileSuit;

namespace ServerInfinite.Persistence.Configurations.Cards.Titles.MobileSuit;

public class MobileSuitTriadTitleConfigurations : IEntityTypeConfiguration<MobileSuitTriadTitle>
{
    public void Configure(EntityTypeBuilder<MobileSuitTriadTitle> builder)
    {
        builder.HasKey(x => x.Id);
    }
}