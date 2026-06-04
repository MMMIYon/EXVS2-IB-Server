using ServerInfinite.Context.Battle;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Enum;

namespace ServerInfinite.Commands.SaveBattle.PvP;

public class SavePlayerStatisticCommand : ISaveBattleDataCommand
{
    private readonly ServerDbContext _context;

    public SavePlayerStatisticCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Save(CardProfile cardProfile, BattleResultContext battleResultContext)
    {
        var playerBattleStatistics = _context.PlayerBattleStatisticDbSet
            .First(x => x.CardProfile == cardProfile);

        var commonDomain = battleResultContext.CommonDomain;
        var battleStatisticDomain = battleResultContext.BattleStatisticDomain;

        var noDamageBattleCount = battleStatisticDomain.NoDamageFlag ? 1u : 0u;
        var tenConsecutiveWinCount = battleStatisticDomain.ConsecutiveWinCount == 10 ? 1u : 0u;
        
        playerBattleStatistics.TotalGivenDamage += battleStatisticDomain.TotalGivenDamage;
        playerBattleStatistics.TotalEnemyDefeatedCount += battleStatisticDomain.TotalEnemyDefeatedCount;
        playerBattleStatistics.TotalNoDamageBattleCount += noDamageBattleCount;
        playerBattleStatistics.TotalExBurstDamage += battleStatisticDomain.TotalExBurstDamage;
        
        if (commonDomain.BattleMode == BattleModeConstant.ClassMatchSolo 
            || commonDomain.BattleMode == BattleModeConstant.ClassMatchTeam)
        {
            playerBattleStatistics.TotalClassMatchTenConsecutiveWinCount += tenConsecutiveWinCount;
        }
    }
}