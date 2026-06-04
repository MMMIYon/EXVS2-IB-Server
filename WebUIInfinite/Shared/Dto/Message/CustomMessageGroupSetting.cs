using WebUIInfinite.Shared.Dto.Enum;

namespace WebUIInfinite.Shared.Dto.Message;

/// <summary>
/// Client-aligned (Q2=A) communication message configuration:
/// MessagePosition / AllowReceiveMessage / CommandMessageAutoFlag at the top, plus
/// three 6-direction groups, one per CommandMessageMode.
/// </summary>
public class CustomMessageGroupSetting
{
    public MessagePosition MessagePosition { get; set; } = MessagePosition.Center;
    public bool AllowReceiveMessage { get; set; } = true;
    public bool CommandMessageAutoFlag { get; set; } = false;

    public CustomMessageGroup SoloGroup { get; set; } = new();
    public CustomMessageGroup TeamGroup { get; set; } = new();
    public CustomMessageGroup InstantTeamGroup { get; set; } = new();
}
