using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Profile;

namespace ServerInfinite.Persistence.Configurations.Cards.Profile;

public class TrainingProfileConfigurations : IEntityTypeConfiguration<TrainingProfile>
{
    public void Configure(EntityTypeBuilder<TrainingProfile> builder)
    {
        builder.HasKey(x => x.Id);
    }
}