using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerInfinite.Handlers.UI.Team;
using WebUIInfinite.Shared.Dto.Request;
using WebUIInfinite.Shared.Dto.Response;

namespace ServerInfinite.Controllers.UI;

[ApiController]
[Route("ui/team")]
public class TeamController : BaseController<TeamController>
{
    private readonly IMediator _mediator;

    public TeamController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("getTeams/{accessCode}/{chipId}")]
    [Produces("application/json")]
    public async Task<ActionResult<TeamResponse>> GetTeams(String accessCode, String chipId)
    {
        var response = await _mediator.Send(new GetCustomizeTeamCommand(accessCode, chipId));
        return response;
    }

    [HttpGet("checkPlayerExistence/{partnerId}/{partnerToken}")]
    [Produces("application/json")]
    public async Task<ActionResult<PlayerExistenceResult>> CheckPlayerExistence(uint partnerId, String partnerToken)
    {
        var response = await _mediator.Send(new CheckPlayerExistenceResultCommand(partnerId, partnerToken));
        return response;
    }
    
    [HttpPost("preCreateTeam")]
    [Produces("application/json")]
    public async Task<ActionResult<PreCreateTeamResponse>> PreCreateTeam([FromBody] PreCreateTeamRequest request)
    {
        var response = await _mediator.Send(new PreCreateTeamCommand(request));
        return response;
    }

    [HttpPost("upsertTeams")]
    [Produces("application/json")]
    public async Task<ActionResult<BasicResponse>> UpsertTeams([FromBody] UpsertTeamsRequest request)
    {
        var response = await _mediator.Send(new UpsertCustomizeTeamCommand(request));
        return response;
    }
}