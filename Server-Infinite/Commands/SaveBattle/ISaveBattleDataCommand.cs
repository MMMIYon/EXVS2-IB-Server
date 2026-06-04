using ServerInfinite.Context.Battle;
using ServerInfinite.Models.Cards;

namespace ServerInfinite.Commands.SaveBattle;

public interface ISaveBattleDataCommand
{
    void Save(CardProfile cardProfile, BattleResultContext battleResultContext);
}