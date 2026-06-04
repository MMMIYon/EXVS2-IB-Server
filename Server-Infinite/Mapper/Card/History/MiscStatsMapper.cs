using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Battle.History;
using WebUIInfinite.Shared.Dto.History.Stats;

namespace ServerInfinite.Mapper.Card.History;

[Mapper]
public static partial class MiscStatsMapper
{
    public static partial MiscStats ToMiscStats(this BattleHistory battleHistory);
}