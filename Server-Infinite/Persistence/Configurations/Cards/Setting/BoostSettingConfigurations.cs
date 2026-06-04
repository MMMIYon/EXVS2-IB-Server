using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Settings;

namespace ServerInfinite.Persistence.Configurations.Cards.Setting;

public class BoostSettingConfigurations : IEntityTypeConfiguration<BoostSetting>
{
    public void Configure(EntityTypeBuilder<BoostSetting> builder)
    {
        builder.HasKey(x => x.Id);
    }
}