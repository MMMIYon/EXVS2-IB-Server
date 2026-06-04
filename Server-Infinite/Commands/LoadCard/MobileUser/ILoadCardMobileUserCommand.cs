using nue.protocol.exvs;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Commands.LoadCard.MobileUser;

public interface ILoadCardMobileUserCommand
{
    void Fill(CardProfile cardProfile, Response.LoadCard.MobileUserGroup mobileUserGroup);
}