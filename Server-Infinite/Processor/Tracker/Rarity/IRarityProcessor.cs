using ServerInfinite.Models.Cards.Battle;

namespace ServerInfinite.Processor.Tracker.Rarity;

public interface IRarityProcessor
{
    uint Calculate(PlayerLevel playerLevel, uint levelRequirement);
}