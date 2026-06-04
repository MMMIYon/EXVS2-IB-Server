using WebUIInfinite.Shared.Dto.Response;

namespace WebUIInfinite.Shared.Dto.Request;

public class UpdateAllMsCostumeSkinRequest : BasicCardRequest
{
    public List<MsSkillGroup> MsSkillGroup { get; set; } = new();
}