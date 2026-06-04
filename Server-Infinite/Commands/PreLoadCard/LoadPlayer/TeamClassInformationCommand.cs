using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;
using ServerInfinite.Processor.Class.Effect;

namespace ServerInfinite.Commands.PreLoadCard.LoadPlayer;

public class TeamClassInformationCommand : IPreLoadPlayerCommand
{
    private readonly ServerDbContext _context;
    private readonly ClassEffectDeterminer _classEffectDeterminer = new ();

    public TeamClassInformationCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.PreLoadCard.LoadPlayer loadPlayer)
    {
        var teamClassInformation = _context.TeamClassMatchRecordDbSet
            .First(x => x.CardProfile == cardProfile);

        loadPlayer.ClassIdTeam = teamClassInformation.ClassId;
        loadPlayer.ClassChangeStatusTeam = teamClassInformation.ClassChangeStatus;
        
        // Phase A schema realignment: the previous tag 40 (TopPointRankNumTeam, uint) was
        // dropped because the newer client schema reuses tag 40 for required float rate_solo.
        // The team-side rank entry count no longer has a destination in this response.
        loadPlayer.RateTeam = teamClassInformation.Rate;
        
        if (teamClassInformation.ClassId < 4)
        {
            return;
        }
        
        var teamRank = _context.TeamOverRankViews
            .FirstOrDefault(rank => rank.CardId == cardProfile.Id && rank.Rank <= 1000);

        if (teamRank is not null)
        {
            loadPlayer.TopPointRankTeam = teamRank.Rank;
            _classEffectDeterminer.Determine(4, teamRank.Rank);
        }
    }
}