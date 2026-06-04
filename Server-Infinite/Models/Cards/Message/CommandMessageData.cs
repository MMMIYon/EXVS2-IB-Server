using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Models.Cards.Settings;

namespace ServerInfinite.Models.Cards.Message;

/// <summary>
/// New client-aligned per-mode command message storage.
/// Each CardProfile/MessageSetting owns 3 rows (one per CommandMessageMode),
/// and each row stores 6 directional slots (start/up/down/left/right/end) of {Id, Text}.
/// Replaces the legacy 6×4 layout (Opening/Playing/Result × Normal/OnlineShuffle)
/// per Q2=A (client semantics first).
/// </summary>
[Table("exvs2ob_command_message_data")]
[Index(nameof(Id))]
[Index(nameof(MessageSettingId))]
[Index(nameof(MessageSettingId), nameof(Mode), IsUnique = true)]
public class CommandMessageData : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }

    [Required]
    public int MessageSettingId { get; set; }

    [Required]
    public CommandMessageMode Mode { get; set; } = CommandMessageMode.Solo;

    public string StartMessageText { get; set; } = string.Empty;

    [Required]
    public uint StartMessageId { get; set; } = 0;

    public string UpMessageText { get; set; } = string.Empty;

    [Required]
    public uint UpMessageId { get; set; } = 0;

    public string DownMessageText { get; set; } = string.Empty;

    [Required]
    public uint DownMessageId { get; set; } = 0;

    public string LeftMessageText { get; set; } = string.Empty;

    [Required]
    public uint LeftMessageId { get; set; } = 0;

    public string RightMessageText { get; set; } = string.Empty;

    [Required]
    public uint RightMessageId { get; set; } = 0;

    public string EndMessageText { get; set; } = string.Empty;

    [Required]
    public uint EndMessageId { get; set; } = 0;

    public virtual MessageSetting MessageSetting { get; set; } = null!;
}
