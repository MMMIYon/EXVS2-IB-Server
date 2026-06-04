using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle;

public class LicenseScoreRecordConfigurations : IEntityTypeConfiguration<LicenseScoreRecord>
{
    public void Configure(EntityTypeBuilder<LicenseScoreRecord> builder)
    {
        builder.HasKey(x => x.Id);
    }
}