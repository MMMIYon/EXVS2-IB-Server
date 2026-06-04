using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Upload;

namespace ServerInfinite.Persistence.Configurations.Cards.Upload;

public class UploadImageConfigurations : IEntityTypeConfiguration<UploadImage>
{
    public void Configure(EntityTypeBuilder<UploadImage> builder)
    {
        builder.HasKey(x => x.ImageId);
    }
}