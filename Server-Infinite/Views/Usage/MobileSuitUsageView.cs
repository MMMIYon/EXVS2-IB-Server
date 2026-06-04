using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Views.Usage;

[Keyless]
public class MobileSuitUsageView
{
    public uint MstMobileSuitId { get; set; } = 0;
    public uint AggregatedTotalBattle { get; set; } = 0;
    public uint AggregatedTotalWin { get; set; } = 0;
}