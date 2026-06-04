using Microsoft.EntityFrameworkCore;

namespace ServerInfinite.Models.Cards.Settings;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("exvs2ob_gamepad_setting")]
[Index(nameof(Id))]
[Index(nameof(CardId))]
public class GamepadSetting : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }
    
    [Required]
    public int CardId { get; set; }
    
    [Required]
    public uint XKey { get; set; } = 1;
    
    [Required]
    public uint YKey { get; set; } = 2;
    
    [Required]
    public uint AKey { get; set; } = 3;
    
    [Required]
    public uint BKey { get; set; } = 4;
    
    [Required]
    public uint LbKey { get; set; } = 5;
    
    [Required]
    public uint RbKey { get; set; } = 6;
    
    [Required]
    public uint LtKey { get; set; } = 7;
    
    [Required]
    public uint RtKey { get; set; } = 8;
    
    [Required]
    public uint LsbKey { get; set; } = 0;
    
    [Required]
    public uint RsbKey { get; set; } = 9;

    // Client: PreLoadCard.MobileUserGroup.game_pad_style (tag 12).
    // 0 = No Gamepad, 1 = Lite Type, 2 = Normal Type (Default), 3 = Normal Type (Custom).
    [Required]
    public uint GamePadStyle { get; set; } = 2;

    // Client: PreLoadCard.MobileUserGroup.CustomizeGroup.command_disp_config (tag 14).
    // Command Display (0 = None, 1 = Arcade button, 2 = Operation name).
    [Required]
    public uint CommandDispConfig { get; set; } = 0;

    public virtual CardProfile CardProfile { get; set; } = null!;
}
