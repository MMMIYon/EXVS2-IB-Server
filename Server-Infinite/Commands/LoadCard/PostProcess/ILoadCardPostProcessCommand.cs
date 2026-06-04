using nue.protocol.exvs;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Commands.LoadCard.PostProcess;

public interface ILoadCardPostProcessCommand
{
    void PostProcess(CardProfile cardProfile, Request.LoadCard loadCardRequest);
}