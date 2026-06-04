using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Titles.User;

namespace ServerInfinite.Persistence.Configurations.Cards.Titles.User;

public class UserClassMatchTitleConfigurations : IEntityTypeConfiguration<UserClassMatchTitle>
{
    public void Configure(EntityTypeBuilder<UserClassMatchTitle> builder)
    {
        builder.HasKey(x => x.Id);
    }
}