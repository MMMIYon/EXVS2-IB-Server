using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Response;

public class TeamResponse
{
    public string DistinctTeamFormationToken { get; set; } = string.Empty;
    public List<Team> Teams { get; set; } = new();
}