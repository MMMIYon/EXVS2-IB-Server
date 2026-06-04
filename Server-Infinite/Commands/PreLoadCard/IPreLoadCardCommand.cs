using nue.protocol.exvs;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Commands.PreLoadCard;

public interface IPreLoadCardCommand
{
    void Fill(CardProfile cardProfile, Response.PreLoadCard preLoadCard);
}