using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Message;

namespace ServerInfinite.Persistence.Configurations.Cards.Message;

public class OpeningMessageConfigurations : IEntityTypeConfiguration<OpeningMessage>
{
    public void Configure(EntityTypeBuilder<OpeningMessage> builder)
    {
        builder.HasKey(x => x.Id);
    }
}