using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Battle.History;
using WebUIInfinite.Shared.Dto.History;

namespace ServerInfinite.Mapper.Card.History;

[Mapper]
public static partial class BattleHistoryPlayerMapper
{
    public static partial BattleHistoryPlayer ToBattleHistoryPlayer(this BattleSelf battleSelf);
    public static partial BattleHistoryPlayer ToBattleHistoryPlayer(this BattleAlly battleAlly);
    public static partial BattleHistoryPlayer ToBattleHistoryPlayer(this BattleTarget battleTarget);
}