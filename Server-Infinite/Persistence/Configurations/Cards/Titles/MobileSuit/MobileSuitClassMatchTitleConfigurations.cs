using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Titles.MobileSuit;

namespace ServerInfinite.Persistence.Configurations.Cards.Titles.MobileSuit;

public class MobileSuitClassMatchTitleConfigurations : IEntityTypeConfiguration<MobileSuitClassMatchTitle>
{
    public void Configure(EntityTypeBuilder<MobileSuitClassMatchTitle> builder)
    {
        builder.HasKey(x => x.Id);
    }
}