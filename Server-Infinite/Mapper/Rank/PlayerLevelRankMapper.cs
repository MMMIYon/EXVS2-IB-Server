using Riok.Mapperly.Abstractions;
using ServerInfinite.Views.Battle;
using WebUIInfinite.Shared.Dto.Rank;

namespace ServerInfinite.Mapper.Rank;

[Mapper]
public static partial class PlayerLevelRankMapper
{
    public static partial PlayerLevelRankDto ToPlayerLevelRankDto(this PlayerLevelRankView playerLevelRankView);
}