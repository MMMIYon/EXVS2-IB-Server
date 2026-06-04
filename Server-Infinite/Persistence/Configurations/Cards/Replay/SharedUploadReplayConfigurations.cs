using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Replay;

namespace ServerInfinite.Persistence.Configurations.Cards.Replay;

public class SharedUploadReplayConfigurations : IEntityTypeConfiguration<SharedUploadReplay>
{
    public void Configure(EntityTypeBuilder<SharedUploadReplay> builder)
    {
        builder.HasKey(x => x.ReplayId);
    }
}