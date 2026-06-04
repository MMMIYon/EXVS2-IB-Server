using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Views.Triad;

[Keyless]
public class WantedDefeatedCountView : TriadRankView
{
    public uint DestroyCount { get; set; }
}