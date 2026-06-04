using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Message;

namespace ServerInfinite.Persistence.Configurations.Cards.Message;

public class OnlineShufflePlayingMessageConfigurations : IEntityTypeConfiguration<OnlineShufflePlayingMessage>
{
    public void Configure(EntityTypeBuilder<OnlineShufflePlayingMessage> builder)
    {
        builder.HasKey(x => x.Id);
    }
}