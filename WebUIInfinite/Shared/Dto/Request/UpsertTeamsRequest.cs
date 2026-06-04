using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Request;

public class UpsertTeamsRequest : BasicCardRequest
{
    public List<Team> Teams { get; set; } = new();
}