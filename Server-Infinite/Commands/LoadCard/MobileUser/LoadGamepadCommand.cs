using nue.protocol.exvs;
using ServerInfinite.Mapper.Card.Setting;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.MobileUser;

public class LoadGamepadCommand : ILoadCardMobileUserCommand
{
    private readonly ServerDbContext _context;

    public LoadGamepadCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.MobileUserGroup mobileUserGroup)
    {
        var gamepadSetting = _context.GamepadSettingDbSet
            .First(x => x.CardProfile == cardProfile);
        
        mobileUserGroup.Gamepad = gamepadSetting.ToGamepadGroup();
    }
}
