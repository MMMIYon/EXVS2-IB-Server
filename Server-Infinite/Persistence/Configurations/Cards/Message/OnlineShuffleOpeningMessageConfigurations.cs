using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Message;

namespace ServerInfinite.Persistence.Configurations.Cards.Message;

public class OnlineShuffleOpeningMessageConfigurations : IEntityTypeConfiguration<OnlineShuffleOpeningMessage>
{
    public void Configure(EntityTypeBuilder<OnlineShuffleOpeningMessage> builder)
    {
        builder.HasKey(x => x.Id);
    }
}