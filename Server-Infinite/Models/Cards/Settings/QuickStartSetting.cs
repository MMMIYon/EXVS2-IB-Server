using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Models.Cards.Settings;

[Table("exvs2ob_quick_start_setting")]
[Index(nameof(Id))]
[Index(nameof(CardId))]
public class QuickStartSetting : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }

    [Required]
    public int CardId { get; set; }

    /// <summary>PreLoadCard.MobileUserGroup.CustomizeGroup tag 13 (`quick_start_flag`).</summary>
    [Required]
    public bool QuickStartFlag { get; set; }

    [Required]
    public uint GameMode { get; set; }

    public uint? RuleType { get; set; }

    [Required]
    public uint TeamType { get; set; }

    [Required]
    public uint MstMobileSuitId0 { get; set; }

    [Required]
    public uint BurstType0 { get; set; }

    [Required]
    public uint MstMobileSuitId1 { get; set; }

    [Required]
    public uint BurstType1 { get; set; }

    [Required]
    public uint StageId { get; set; }

    public virtual CardProfile CardProfile { get; set; } = null!;
}
