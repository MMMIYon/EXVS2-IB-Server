using nue.protocol.exvs;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Strategy.Team;

public interface ITagTeamAppendStrategy
{
    void Append(CardProfile cardProfile, List<TagTeamGroup> tagTeams);
}