using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Profile;

namespace ServerInfinite.Persistence.Configurations.Cards.Profile;

public class CustomizeProfileConfigurations : IEntityTypeConfiguration<CustomizeProfile>
{
    public void Configure(EntityTypeBuilder<CustomizeProfile> builder)
    {
        builder.HasKey(x => x.Id);
    }
}