using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerInfinite.Models.Cards.Titles.User;

namespace ServerInfinite.Persistence.Configurations.Cards.Titles.User;

public class UserTriadTitleConfigurations : IEntityTypeConfiguration<UserTriadTitle>
{
    public void Configure(EntityTypeBuilder<UserTriadTitle> builder)
    {
        builder.HasKey(x => x.Id);
    }
}