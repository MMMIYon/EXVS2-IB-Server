using nue.protocol.exvs;
using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Settings;
using WebUIInfinite.Shared.Dto.Common;

namespace ServerInfinite.Mapper.Card.Setting;

[Mapper]
public static partial class GamepadMapper
{
    public static partial Response.LoadCard.MobileUserGroup.GamepadGroup ToGamepadGroup(this GamepadSetting gamepadSetting);
    public static partial GamepadConfig ToGamepadConfig(this GamepadSetting gamepadSetting);
}