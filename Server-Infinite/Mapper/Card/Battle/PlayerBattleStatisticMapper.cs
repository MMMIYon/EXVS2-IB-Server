using Riok.Mapperly.Abstractions;
using ServerInfinite.Context.Tracker;
using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Mapper.Card.Battle;

[Mapper]
public static partial class PlayerBattleStatisticMapper
{
    public static partial PilotTrackerContext ToPilotTrackerContext(this PlayerBattleStatistic playerBattleStatistic);
}