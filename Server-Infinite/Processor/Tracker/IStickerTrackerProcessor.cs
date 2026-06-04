using nue.protocol.exvs;
using ServerInfinite.Models.Cards.Battle;
using ServerInfinite.Models.Cards.MobileSuit;

namespace ServerInfinite.Processor.Tracker;

public interface IStickerTrackerProcessor
{
    void Process(Response.LoadCard.MobileUserGroup.PlayerSticker.Tracker tracker, MobileSuitPvPStatistic? mobileSuitPvPStatistic, PlayerLevel playerLevel);
}