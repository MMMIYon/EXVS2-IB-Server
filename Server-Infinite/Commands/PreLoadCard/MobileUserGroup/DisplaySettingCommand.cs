using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.PreLoadCard.MobileUserGroup;

public class DisplaySettingCommand : IPreLoadMobileUserGroupCommand
{
    private readonly ServerDbContext _context;

    public DisplaySettingCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.PreLoadCard.MobileUserGroup mobileUserGroup)
    {
        var playerProfile = _context.PlayerProfileDbSet
            .First(x => x.CardProfile == cardProfile);

        mobileUserGroup.OpenRecord = playerProfile.OpenRecord;
        // Client: `open_player_level` (bool). DB/WebUI `OpenEchelon`: 1 = on/true, 0 = off/false.
        mobileUserGroup.OpenPlayerLevel = playerProfile.OpenEchelon != 0;
        mobileUserGroup.OpenSkillpoint = playerProfile.OpenSkillpoint;
    }
}