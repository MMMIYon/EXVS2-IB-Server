using System.ComponentModel.DataAnnotations;

namespace ServerInfinite.Models;

public class BaseEntity
{
    [Required]
    public DateTime CreateTime { get; set; } = DateTime.Now;
    
    [Required]
    public DateTime UpdateTime { get; set; } = DateTime.Now;
}