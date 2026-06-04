using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerInfinite.Handlers.UI.Rank;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Rank;

namespace ServerInfinite.Controllers.UI.Rank;

[ApiController]
[Route("ui/rank/player-level-rank")]
public class PlayerLevelRankController(IMediator mediator, ServerDbContext context) : BaseController<PlayerLevelRankController>
{
    [HttpGet("getPlayerLevelRanks")]
    [Produces("application/json")]
    public async Task<PlayerLevelRankData> GetPlayerLevelRanks()
    {
        var response = await mediator.Send(new GetPlayerLevelRankCommand());
        return response;
    }
}