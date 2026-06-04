using Microsoft.EntityFrameworkCore;
using nue.protocol.exvs;
using ServerInfinite.Constants;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Strategy.Team;

public class PlayerPartnerTeamAppendStrategy : ITagTeamAppendStrategy
{
    private readonly ServerDbContext _context;

    public PlayerPartnerTeamAppendStrategy(ServerDbContext context)
    {
        _context = context;
    }

    public void Append(CardProfile cardProfile, List<TagTeamGroup> tagTeams)
    {
        _context.TagTeamDataDbSet
            .Where(x => x.TeammateCardId == cardProfile.Id)
            .ToList()
            .ForEach(tagTeam =>
            {
                var group = TagTeamGroupBuilder.Build(_context, tagTeam, partnerCardId: tagTeam.CardId);
                tagTeams.Add(group);
            });
    }
}