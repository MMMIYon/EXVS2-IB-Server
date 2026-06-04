using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerInfinite.Handlers.UI.Triad;
using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Dto.Request;
using WebUIInfinite.Shared.Dto.Response;
using WebUIInfinite.Shared.Dto.Triad;
using WebUIInfinite.Shared.Validator;

namespace ServerInfinite.Controllers.UI;

[ApiController]
[Route("ui/triad")]
public class TriadController : BaseController<TriadController>
{
    private readonly IMediator _mediator;

    public TriadController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // Triad CPU partner editing endpoints removed because the new client schema
    // no longer exposes the field. Restore the block below to reinstate WebUI editing.
#if FALSE
    [HttpGet("getCpuTriadPartner/{accessCode}/{chipId}")]
    [Produces("application/json")]
    public async Task<ActionResult<CpuTriadPartner>> GetCpuTriadPartner(String accessCode, String chipId)
    {
        var response = await _mediator.Send(new GetCpuTriadPartnerCommand(accessCode, chipId));
        return response;
    }

    [HttpPost("updateCpuTriadPartner")]
    [Produces("application/json")]
    public async Task<ActionResult<BasicResponse>> UpdateCpuTriadPartner(
        [FromBody] UpdateCpuTriadPartnerRequest request)
    {
        bool validateResult = new CpuTriadPartnerValidator().Validate(request.CpuTriadPartner);

        if (!validateResult)
        {
            return BadRequest(
                new ErrorResponse
                {
                    ErrorMsg =
                        "Please double check the level... Each of them are maxed at 100, and total is maxed at 500"
                });
        }

        var response = await _mediator.Send(new UpdateCpuTriadPartnerCommand(request));
        return response;
    }
#endif

    [HttpGet("getTriadCourseOverallResult/{accessCode}/{chipId}")]
    [Produces("application/json")]
    public async Task<ActionResult<TriadCourseOverallResult>> GetTriadCourseResults(String accessCode, String chipId)
    {
        var response = await _mediator.Send(new GetTriadCourseResultsCommand(accessCode, chipId));
        return response;
    }
}