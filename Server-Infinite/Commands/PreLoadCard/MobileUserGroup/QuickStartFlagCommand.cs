using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.PreLoadCard.MobileUserGroup;

public class QuickStartFlagCommand : IPreLoadMobileUserGroupCommand
{
    private readonly ServerDbContext _context;

    public QuickStartFlagCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.PreLoadCard.MobileUserGroup mobileUserGroup)
    {
        var setting = _context.GeneralSettingDbSet
            .First(x => x.CardProfile == cardProfile);

        mobileUserGroup.customize_group.QuickStartFlag = setting.EnableQuickStart;
    }
}
