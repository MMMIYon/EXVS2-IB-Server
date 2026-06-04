using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerInfinite.Handlers.UI.Gamepad;
using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Dto.Request;
using WebUIInfinite.Shared.Dto.Response;

namespace ServerInfinite.Controllers.UI;

[ApiController]
[Route("ui/gamepad")]
public class GamePadController : BaseController<GamePadController>
{
    private readonly IMediator _mediator;

    public GamePadController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("getGamepadConfig/{accessCode}/{chipId}")]
    [Produces("application/json")]
    public async Task<ActionResult<GamepadConfig>> GetGamepadConfig(String accessCode, String chipId)
    {
        var response = await _mediator.Send(new GetGamepadConfigCommand(accessCode, chipId));
        return response;
    }
    
    [HttpPost("upsertGamepadConfig")]
    [Produces("application/json")]
    public async Task<ActionResult<BasicResponse>> UpsertGamepadConfig([FromBody] UpsertGamepadConfigRequest request)
    {
        var response = await _mediator.Send(new UpsertGamepadConfigCommand(request));
        return response;
    }
}