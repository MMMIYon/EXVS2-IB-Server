using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.PreLoadCard.MobileUserGroup;

public class PreLoadMobileUserBasicInformationCommand : IPreLoadMobileUserGroupCommand
{
    private readonly ServerDbContext _context;

    public PreLoadMobileUserBasicInformationCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.PreLoadCard.MobileUserGroup mobileUserGroup)
    {
        mobileUserGroup.UserId = (uint)cardProfile.Id;
        mobileUserGroup.PlayerName = cardProfile.UserName;
        mobileUserGroup.KeyconfigNumber = 1;
        mobileUserGroup.Gp = cardProfile.Gp;
    }
}