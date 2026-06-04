using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Battle.History;
using WebUIInfinite.Shared.Dto.History;

namespace ServerInfinite.Mapper.Card.History;

[Mapper]
public static partial class BattleHistoryActionItemMapper
{
    public static partial BattleHistoryActionItem ToBattleHistoryActionItem(this BattleActionLog battleActionLog);
}