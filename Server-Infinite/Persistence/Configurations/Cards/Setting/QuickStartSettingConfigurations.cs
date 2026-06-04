using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Settings;

namespace ServerInfinite.Persistence.Configurations.Cards.Setting;

public class QuickStartSettingConfigurations : IEntityTypeConfiguration<QuickStartSetting>
{
    public void Configure(EntityTypeBuilder<QuickStartSetting> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
