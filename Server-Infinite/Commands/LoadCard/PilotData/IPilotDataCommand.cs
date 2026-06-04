using nue.protocol.exvs;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Commands.LoadCard.PilotData;

public interface IPilotDataCommand
{
    void Fill(CardProfile cardProfile, Response.LoadCard.PilotDataGroup pilotDataGroup);
}