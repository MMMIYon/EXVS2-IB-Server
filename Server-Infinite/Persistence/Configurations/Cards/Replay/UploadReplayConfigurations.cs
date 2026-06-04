using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Replay;

namespace ServerInfinite.Persistence.Configurations.Cards.Replay;

public class UploadReplayConfigurations : IEntityTypeConfiguration<UploadReplay>
{
    public void Configure(EntityTypeBuilder<UploadReplay> builder)
    {
        builder.HasKey(x => x.ReplayId);
    }
}