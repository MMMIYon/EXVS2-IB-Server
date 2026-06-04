using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Models.Cards.Profile;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("exvs2ob_player_profile")]
[Index(nameof(Id))]
[Index(nameof(CardId))]
public class PlayerProfile : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }
    
    [Required]
    public int CardId { get; set; }
    
    [Required]
    public uint OpenRecord { get; set; } = 1;
    
    [Required]
    /// <summary>1 = open_player_level true; 0 = false. Maps to PreLoadCard <c>open_player_level</c>.</summary>
    public uint OpenEchelon { get; set; } = 0;
    
    [Required]
    public bool OpenSkillpoint { get; set; } = true;

    [Required] 
    public uint FullLoadCardCount { get; set; } = 0;
    
    [Required] 
    public bool ExTutorialDispFlag { get; set; } = false;
    
    public virtual CardProfile CardProfile { get; set; } = null!;
}