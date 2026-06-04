using nue.protocol.exvs;
using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Titles.User;

namespace ServerInfinite.Mapper.Card.Titles.User;

[Mapper]
public static partial class UserTitleMapper
{
    public static partial TitleCustomize ToTitleCustomize(this UserTitle msTitle);
}