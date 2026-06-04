using Microsoft.EntityFrameworkCore;
using nue.protocol.exvs;
using ServerInfinite.Mapper.Card.Titles.User;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.MobileUser;

public class LoadTitleCommand : ILoadCardMobileUserCommand
{
    private readonly ServerDbContext _context;

    public LoadTitleCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.MobileUserGroup mobileUserGroup)
    {
        var userTitleSetting = _context.UserTitleSettingDbSet
            .Include(x => x.UserTriadTitle)
            .Include(x => x.UserClassMatchTitle)
            .First(x => x.CardProfile == cardProfile);

        mobileUserGroup.TriadTitleCustomize = userTitleSetting.UserTriadTitle.ToTitleCustomize();
        mobileUserGroup.ClassMatchTitleCustomize = userTitleSetting.UserClassMatchTitle.ToTitleCustomize();
    }
}