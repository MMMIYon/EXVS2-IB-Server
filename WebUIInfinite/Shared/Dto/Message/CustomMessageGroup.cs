namespace WebUIInfinite.Shared.Dto.Message;

/// <summary>
/// Client-aligned 6-direction command message group (Q2=A).
/// Each direction stores a textual message and an optional stamp id.
/// One CustomMessageGroup corresponds to one CommandMessageMode (Solo / Team / InstantTeam).
/// </summary>
public class CustomMessageGroup
{
    public CustomMessage StartMessage { get; set; } = new();
    public CustomMessage UpMessage { get; set; } = new();
    public CustomMessage DownMessage { get; set; } = new();
    public CustomMessage LeftMessage { get; set; } = new();
    public CustomMessage RightMessage { get; set; } = new();
    public CustomMessage EndMessage { get; set; } = new();
}
