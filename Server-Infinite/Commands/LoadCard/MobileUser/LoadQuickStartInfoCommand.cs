using nue.protocol.exvs;
using ServerInfinite.Mapper.Card.QuickStart;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.MobileUser;

public class LoadQuickStartInfoCommand : ILoadCardMobileUserCommand
{
    private readonly ServerDbContext _context;

    public LoadQuickStartInfoCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.MobileUserGroup mobileUserGroup)
    {
        var generalSetting = _context.GeneralSettingDbSet
            .First(x => x.CardProfile == cardProfile);

        if (!generalSetting.EnableQuickStart)
            return;

        var setting = _context.QuickStartSettingDbSet
            .First(x => x.CardProfile == cardProfile);

        mobileUserGroup.quick_start_info = QuickStartInfoMapper.ToProto(setting);
    }
}
