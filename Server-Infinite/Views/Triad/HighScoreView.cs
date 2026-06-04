using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Views.Triad;

[Keyless]
public class HighScoreView : TriadRankView
{
    public uint CourseHighScore { get; set; }
}