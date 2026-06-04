namespace WebUIInfinite.Shared.Dto.Common;

public class GamepadConfig
{
    public uint XKey { get; set; } = 1;
    public uint YKey { get; set; } = 2;
    public uint AKey { get; set; } = 3;
    public uint BKey { get; set; } = 4;
    public uint LbKey { get; set; } = 5;
    public uint RbKey { get; set; } = 6;
    public uint LtKey { get; set; } = 7;
    public uint RtKey { get; set; } = 8;
    public uint LsbKey { get; set; } = 0;
    public uint RsbKey { get; set; } = 9;

    // PreLoadCard.MobileUserGroup.game_pad_style (tag 12).
    public uint GamePadStyle { get; set; } = 2;

    // PreLoadCard.MobileUserGroup.CustomizeGroup.command_disp_config (tag 14).
    public uint CommandDispConfig { get; set; } = 0;
}
