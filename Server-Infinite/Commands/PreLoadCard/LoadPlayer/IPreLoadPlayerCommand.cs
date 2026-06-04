using nue.protocol.exvs;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Commands.PreLoadCard.LoadPlayer;

public interface IPreLoadPlayerCommand
{
    void Fill(CardProfile cardProfile, Response.PreLoadCard.LoadPlayer loadPlayer);
}