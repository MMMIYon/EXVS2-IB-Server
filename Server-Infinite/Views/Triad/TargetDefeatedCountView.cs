using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Views.Triad;

[Keyless]
public class TargetDefeatedCountView : TriadRankView
{
    public uint DestroyCount { get; set; }
}