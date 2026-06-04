using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Boot;

namespace ServerInfinite.Persistence.Configurations.Boot;

public class InvalidVisitConfigurations : IEntityTypeConfiguration<InvalidVisit>
{
    public void Configure(EntityTypeBuilder<InvalidVisit> builder)
    {
        builder.HasKey(x => x.Id);
    }
}