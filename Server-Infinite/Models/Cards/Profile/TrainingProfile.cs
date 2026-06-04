using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Models.Cards.Profile;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("exvs2ob_training_profile")]
[Index(nameof(Id))]
[Index(nameof(CardId))]
public class TrainingProfile : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }
    
    [Required]
    public int CardId { get; set; }

    [Required]
    public uint MstMobileSuitId { get; set; } = 1;
    
    [Required]
    public uint BurstType { get; set; } = 0;
    
    [Required]
    public uint CpuLevel { get; set; } = 1;
    
    [Required]
    public uint ExBurstGauge { get; set; } = 0;
    
    [Required]
    public bool DamageDisplay { get; set; } = true;
    
    [Required]
    public bool CpuAutoGuard { get; set; } = true;
    
    // Client-aligned: command_guide_display switched from bool to uint32 (0=None,
    // 1=Arcade button, 2=Operation name).
    [Required]
    public uint CommandGuideDisplay { get; set; } = 0;

    // Client-aligned new optional fields (TrainingSettingGroup tags 8-11). Stored so they
    // survive a round-trip through the WebUI editor. `Armor` is a uint level (0=100%,
    // 1=50%, 2=33%, 3=25%, 4=20%); the others are simple toggles.
    [Required]
    public uint Armor { get; set; } = 0;

    [Required]
    public bool CpuAutoHeal { get; set; } = false;

    [Required]
    public bool ExOverLimit { get; set; } = false;

    [Required]
    public bool FastReload { get; set; } = false;

    public virtual CardProfile CardProfile { get; set; } = null!;
}