using WebUIInfinite.Shared.Dto.History;
using WebUIInfinite.Shared.Dto.Triad;

namespace WebUIInfinite.Client.Context.ViewCard;

public class ViewCardContext
{
    public string AccessCode { get; set; } = string.Empty;
    public string ChipId { get; set; } = string.Empty;
    public TriadCourseOverallResult TriadCourseOverallResult { get; set; } = new();
    public List<BattleHistorySummary> BattleHistorySummaries { get; set; } = new();
}