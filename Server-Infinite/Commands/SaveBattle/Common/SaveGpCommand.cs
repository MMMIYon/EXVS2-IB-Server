using ServerInfinite.Context.Battle;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.SaveBattle.Common;

public class SaveGpCommand : ISaveBattleDataCommand
{
    private readonly ServerDbContext _context;

    public SaveGpCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Save(CardProfile cardProfile, BattleResultContext battleResultContext)
    {
        cardProfile.Gp += battleResultContext.CommonDomain.GpIncrement;
    }
}