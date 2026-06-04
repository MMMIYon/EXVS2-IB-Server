using nue.protocol.exvs;
using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.MobileSuit;
using WebUIInfinite.Shared.Dto.Response;

namespace ServerInfinite.Mapper.Card.MobileSuit;

[Mapper]
public static partial class MobileSuitUsageMapper
{
    public static partial Response.LoadCard.PilotDataGroup.MSSkillGroup ToMSSkillGroup(this MobileSuitUsage navi);
    public static partial MsSkillGroup ToMSSkillGroupDto(this MobileSuitUsage navi);
}