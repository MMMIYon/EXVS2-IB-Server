using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.PreLoadCard.LoadPlayer;

public class PreLoadPlayerBasicInformationCommand : IPreLoadPlayerCommand
{
    private readonly ServerDbContext _context;

    public PreLoadPlayerBasicInformationCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.PreLoadCard.LoadPlayer loadPlayer)
    {
        var playerProfile = _context.PlayerProfileDbSet
            .First(x => x.CardProfile == cardProfile);
        
        loadPlayer.PilotId = (uint)cardProfile.Id;
        loadPlayer.LastPlayedAt = cardProfile.LastPlayedAt;

        // Stub: client PreLoadCard.LoadPlayer tags 13–14 (vsm_after_class_change_*). Not computed yet.
        loadPlayer.VsmAfterClassChangeSolo = 0;
        loadPlayer.VsmAfterClassChangeTeam = 0;

        loadPlayer.ExTutorialPlayableFlag = playerProfile.ExTutorialDispFlag;
    }
}