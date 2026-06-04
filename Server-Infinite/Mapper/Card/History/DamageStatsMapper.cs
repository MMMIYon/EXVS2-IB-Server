using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Battle.History;
using WebUIInfinite.Shared.Dto.History.Stats;

namespace ServerInfinite.Mapper.Card.History;

[Mapper]
public static partial class DamageStatsMapper
{
    public static partial DamageStats ToDamageStats(this BattleHistory battleHistory);
}