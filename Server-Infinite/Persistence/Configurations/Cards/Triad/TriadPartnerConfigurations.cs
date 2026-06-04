using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Triad;

namespace ServerInfinite.Persistence.Configurations.Cards.Triad;

public class TriadPartnerConfigurations : IEntityTypeConfiguration<TriadPartner>
{
    public void Configure(EntityTypeBuilder<TriadPartner> builder)
    {
        builder.HasKey(x => x.Id);
    }
}