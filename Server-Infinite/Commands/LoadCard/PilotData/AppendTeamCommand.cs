using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Strategy.Team;

namespace ServerInfinite.Commands.LoadCard.PilotData;

public class AppendTeamCommand : IPilotDataCommand
{
    private readonly ITagTeamAppendStrategy _tagTeamAppendStrategy;

    public AppendTeamCommand(ITagTeamAppendStrategy tagTeamAppendStrategy)
    {
        _tagTeamAppendStrategy = tagTeamAppendStrategy;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.PilotDataGroup pilotDataGroup)
    {
        _tagTeamAppendStrategy.Append(cardProfile, pilotDataGroup.TagTeams);
    }
}