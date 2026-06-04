using nue.protocol.exvs;
using Riok.Mapperly.Abstractions;
using ServerInfinite.Context.Battle;

namespace ServerInfinite.Mapper.Context;

[Mapper]
public static partial class PracticeResultMapper
{
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.WinFlag) },
        new[] { nameof(BattleResultContext.CommonDomain), nameof(BattleResultContext.CommonDomain.IsWin) }
    )]
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.LevelId) },
        new[] { nameof(BattleResultContext.PlayerLevelDomain), nameof(BattleResultContext.PlayerLevelDomain.LevelIdBefore) }
    )]
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.PlayerLevelId) },
        new[] { nameof(BattleResultContext.PlayerLevelDomain), nameof(BattleResultContext.PlayerLevelDomain.LevelIdAfter) }
    )]
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.LevelExp) },
        new[] { nameof(BattleResultContext.PlayerLevelDomain), nameof(BattleResultContext.PlayerLevelDomain.ExpIncrement) }
    )]
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.GuestNavId) },
        new[] { nameof(BattleResultContext.NaviDomain), nameof(BattleResultContext.NaviDomain.GuestNavId) }
    )]
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.GuestNavFamiliarity) },
        new[] { nameof(BattleResultContext.NaviDomain), nameof(BattleResultContext.NaviDomain.GuestNavFamiliarityIncrement) }
    )]
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.SkillPointMobileSuitId) },
        new[] { nameof(BattleResultContext.MobileSuitMasteryDomain), nameof(BattleResultContext.MobileSuitMasteryDomain.MasteryMobileSuitId) }
    )]
    [MapProperty(
        new[] { nameof(Request.SavePracticeResult.PlayResultGroup.MstMobileSuitId) },
        new[] { nameof(BattleResultContext.MobileSuitMasteryDomain), nameof(BattleResultContext.MobileSuitMasteryDomain.ActualMobileSuitId) }
    )]
    public static partial BattleResultContext ToBattleResultContext(this Request.SavePracticeResult.PlayResultGroup resultGroup);
}
