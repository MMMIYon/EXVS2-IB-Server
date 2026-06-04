using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.PreLoadCard.LoadPlayer;

public class PlayerLevelCommand : IPreLoadPlayerCommand
{
    private readonly ServerDbContext _context;

    public PlayerLevelCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.PreLoadCard.LoadPlayer loadPlayer)
    {
        var playerLevel = _context.PlayerLevelDbSet
            .First(x => x.CardProfile == cardProfile);

        loadPlayer.PlayerLevelId = playerLevel.PlayerLevelId;
        // loadPlayer.PrestigeId = playerLevel.PrestigeId; // not on client PreLoadCard.LoadPlayer wire
        loadPlayer.PlayerExp = playerLevel.PlayerExp;
        loadPlayer.LevelMaxDispFlag = playerLevel.LevelMaxDispFlag;
    }
}