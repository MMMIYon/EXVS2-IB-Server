using System.ComponentModel.DataAnnotations;
using ServerInfinite.Models.Cards.MobileSuit;

namespace ServerInfinite.Models.Cards.Titles.MobileSuit;

public class MobileSuitTitle : BaseTitle
{
    [Required]
    public int FavouriteMobileSuitId { get; set; }
    
    public virtual FavouriteMobileSuit FavouriteMobileSuit { get; set; } = null!;
}