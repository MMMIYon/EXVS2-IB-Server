using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Triad;

namespace ServerInfinite.Persistence.Configurations.Cards.Triad;

public class TriadMiscInfoConfigurations : IEntityTypeConfiguration<TriadMiscInfo>
{
    public void Configure(EntityTypeBuilder<TriadMiscInfo> builder)
    {
        builder.HasKey(x => x.Id);
    }
}