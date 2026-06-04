using Microsoft.EntityFrameworkCore;
using nue.protocol.exvs;
using ServerInfinite.Constants;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Strategy.Team;

public class PlayerLeaderTeamAppendStrategy : ITagTeamAppendStrategy
{
    private readonly ServerDbContext _context;

    public PlayerLeaderTeamAppendStrategy(ServerDbContext context)
    {
        _context = context;
    }

    public void Append(CardProfile cardProfile, List<TagTeamGroup> tagTeams)
    {
        _context.TagTeamDataDbSet
            .Where(x => x.CardProfile == cardProfile && x.CardId == cardProfile.Id)
            .ToList()
            .ForEach(tagTeam =>
            {
                var group = TagTeamGroupBuilder.Build(_context, tagTeam, partnerCardId: (int)tagTeam.TeammateCardId);
                tagTeams.Add(group);
            });
    }
}