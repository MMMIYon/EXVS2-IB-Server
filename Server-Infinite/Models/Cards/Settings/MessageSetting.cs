using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Models.Cards.Message;

namespace ServerInfinite.Models.Cards.Settings;

[Table("exvs2ob_message_setting")]
[Index(nameof(MessageSettingId))]
[Index(nameof(CardId))]
public class MessageSetting : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MessageSettingId { get; }
    
    [Required]
    public int CardId { get; set; }

    [Required] 
    public uint MessagePosition { get; set; } = 0;

    [Required] 
    public bool AllowReceiveMessage { get; set; } = true;

    // Client-aligned new field (Q2=A): toggles client-side "command message auto" UI flag.
    [Required]
    public bool CommandMessageAutoFlag { get; set; } = false;

    [Required] 
    public OpeningMessage OpeningMessage { get; set; } = new();
    
    [Required] 
    public PlayingMessage PlayingMessage { get; set; } = new();
    
    [Required] 
    public ResultMessage ResultMessage { get; set; } = new();
    
    [Required] 
    public OnlineShuffleOpeningMessage OnlineShuffleOpeningMessage { get; set; } = new();
    
    [Required] 
    public OnlineShufflePlayingMessage OnlineShufflePlayingMessage { get; set; } = new();
    
    [Required] 
    public OnlineShuffleResultMessage OnlineShuffleResultMessage { get; set; } = new();

    // New client-aligned per-mode storage (Q2=A). Rows are created on first WebUI save / upsert.
    // Do not seed default CommandMessageData instances here: EF attaches them as Id=0 phantom
    // entities and Upsert updates those instead of inserting real rows.
    public ICollection<CommandMessageData> CommandMessageDatas { get; set; } = new List<CommandMessageData>();

    public virtual CardProfile CardProfile { get; set; } = null!;
}