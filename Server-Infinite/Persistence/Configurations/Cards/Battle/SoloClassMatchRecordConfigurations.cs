using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle;

public class SoloClassMatchRecordConfigurations : IEntityTypeConfiguration<SoloClassMatchRecord>
{
    public void Configure(EntityTypeBuilder<SoloClassMatchRecord> builder)
    {
        builder.HasKey(x => x.Id);
    }
}