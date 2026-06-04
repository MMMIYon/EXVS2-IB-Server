using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Triad;

namespace ServerInfinite.Persistence.Configurations.Cards.Triad;

public class TriadCourseDataConfigurations : IEntityTypeConfiguration<TriadCourseData>
{
    public void Configure(EntityTypeBuilder<TriadCourseData> builder)
    {
        builder.HasKey(x => x.Id);
    }
}