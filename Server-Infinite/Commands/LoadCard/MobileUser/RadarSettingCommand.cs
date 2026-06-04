using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.MobileUser;

public class RadarSettingCommand : ILoadCardMobileUserCommand
{
    private readonly ServerDbContext _context;

    public RadarSettingCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.MobileUserGroup mobileUserGroup)
    {
        var generalSetting = _context.GeneralSettingDbSet
            .First(x => x.CardProfile == cardProfile);
        
        mobileUserGroup.RadarType = generalSetting.FixPositionRadar;
    }
}