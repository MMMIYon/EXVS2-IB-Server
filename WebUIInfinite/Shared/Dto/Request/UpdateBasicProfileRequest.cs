using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Request;

public class UpdateBasicProfileRequest : BasicCardRequest
{
    public BasicProfile BasicProfile { get; set; } = new();
}