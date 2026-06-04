using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Models.Cards.Room;

namespace ServerInfinite.Persistence.Configurations.Cards.Room;

public class PrivateMatchRoomConfigurations : IEntityTypeConfiguration<PrivateMatchRoom>
{
    public void Configure(EntityTypeBuilder<PrivateMatchRoom> builder)
    {
        builder.HasKey(x => x.Id);
    }
}