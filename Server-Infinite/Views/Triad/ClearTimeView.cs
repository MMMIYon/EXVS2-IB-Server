using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Views.Triad;

[Keyless]
public class ClearTimeView : TriadRankView
{
    public uint CourseClearTime { get; set; }
}