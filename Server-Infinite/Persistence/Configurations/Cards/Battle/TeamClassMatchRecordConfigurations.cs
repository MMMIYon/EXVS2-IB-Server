using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Persistence.Configurations.Cards.Battle;

public class TeamClassMatchRecordConfigurations : IEntityTypeConfiguration<TeamClassMatchRecord>
{
    public void Configure(EntityTypeBuilder<TeamClassMatchRecord> builder)
    {
        builder.HasKey(x => x.Id);
    }
}