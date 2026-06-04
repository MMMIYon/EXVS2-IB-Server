using nue.protocol.exvs;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Commands.PreLoadCard.MobileUserGroup;

public interface IPreLoadMobileUserGroupCommand
{
    void Fill(CardProfile cardProfile, Response.PreLoadCard.MobileUserGroup mobileUserGroup);
}