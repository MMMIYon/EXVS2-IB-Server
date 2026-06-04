using WebUIInfinite.Shared.Dto.Player;

namespace WebUIInfinite.Shared.Dto.Rank;

public class PlayerLevelRankData
{
    public List<PlayerLevelRankDto> PlayerLevelRanks { get; set; } = new();
    public ExpRequirement ExpRequirement { get; set; } = new();
}