using nue.protocol.exvs;
using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Team;

namespace ServerInfinite.Mapper.Card.Team;

[Mapper]
public static partial class TeamMapper
{
    [MapProperty(nameof(TagTeamData.TeamName), nameof(WebUIInfinite.Shared.Dto.Common.Team.Name))]
    public static partial WebUIInfinite.Shared.Dto.Common.Team ToTeam(this TagTeamData tagTeamData);
    
    public static partial TagTeamGroup ToTagTeamGroup(this WebUIInfinite.Shared.Dto.Common.Team team);
}