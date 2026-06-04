using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Room;
using ServerInfinite.Models.Cards.Settings;

namespace ServerInfinite.Persistence.Configurations.Cards.Setting;

public class PrivateMatchRoomSettingConfigurations : IEntityTypeConfiguration<PrivateMatchRoomSetting>
{
    public void Configure(EntityTypeBuilder<PrivateMatchRoomSetting> builder)
    {
        builder.HasKey(x => x.PrivateMatchRoomSettingId);
        
        builder.HasOne(e => e.SelfPrivateRoomConfig)
            .WithOne(e => e.PrivateMatchRoomSetting)
            .HasForeignKey<PrivateMatchRoom>(e => e.PrivateMatchRoomSettingId)
            .IsRequired();
    }
}