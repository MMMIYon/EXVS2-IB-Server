using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Request;

public class UpsertGamepadConfigRequest : BasicCardRequest
{
    public GamepadConfig GamepadConfig { get; set; } = new();
}