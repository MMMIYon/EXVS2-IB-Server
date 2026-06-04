using WebUIInfinite.Shared.Dto.Message;

namespace WebUIInfinite.Shared.Dto.Request;

public class UpsertCustomMessagesRequest : BasicCardRequest
{
    public CustomMessageGroupSetting MessageSetting { get; set; } = new();
}