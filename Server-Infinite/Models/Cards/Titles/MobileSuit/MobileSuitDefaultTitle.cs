using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Models.Cards.Titles.MobileSuit;

[Table("exvs2ob_ms_default_title")]
[Index(nameof(Id))]
[Index(nameof(FavouriteMobileSuitId))]
public class MobileSuitDefaultTitle : MobileSuitTitle
{
}