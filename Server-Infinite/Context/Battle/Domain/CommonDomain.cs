using WebUIInfinite.Shared.Dto.Enum;

namespace ServerInfinite.Context.Battle.Domain;

public class CommonDomain
{
    public string BattleMode { get; set; } = BattleModeConstant.Triad;
    public bool IsWin { get; set; } = true;
    public uint GpIncrement { get; set; } = 0;
}