using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Message;

namespace ServerInfinite.Persistence.Configurations.Cards.Message;

public class ResultMessageConfigurations : IEntityTypeConfiguration<ResultMessage>
{
    public void Configure(EntityTypeBuilder<ResultMessage> builder)
    {
        builder.HasKey(x => x.Id);
    }
}