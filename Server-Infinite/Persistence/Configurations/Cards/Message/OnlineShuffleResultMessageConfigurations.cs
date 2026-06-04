using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Message;

namespace ServerInfinite.Persistence.Configurations.Cards.Message;

public class OnlineShuffleResultMessageConfigurations : IEntityTypeConfiguration<OnlineShuffleResultMessage>
{
    public void Configure(EntityTypeBuilder<OnlineShuffleResultMessage> builder)
    {
        builder.HasKey(x => x.Id);
    }
}