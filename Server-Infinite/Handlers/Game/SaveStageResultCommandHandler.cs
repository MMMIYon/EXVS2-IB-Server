using MediatR;
using nue.protocol.exvs;
using ServerInfinite.Persistence;

namespace ServerInfinite.Handlers.Game;

public record SaveStageResultCommand(Request Request) : IRequest<Response>;

public class SaveStageResultCommandHandler : IRequestHandler<SaveStageResultCommand, Response>
{
    private readonly ServerDbContext _context;

    public SaveStageResultCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<Response> Handle(SaveStageResultCommand request, CancellationToken cancellationToken)
    {
        var saveRequest = request.Request.save_stage_result;
        var cardProfile = _context.CardProfiles
            .FirstOrDefault(x => x.SessionId == saveRequest.SessionId && x.Id == saveRequest.PilotId);

        if (cardProfile == null)
        {
            return Task.FromResult(SuccessResponse(request));
        }

        // Stage-mode persistence (gauge/progress/save_data_info) is not implemented yet;
        // accept the payload so the client can continue after battle.
        return Task.FromResult(SuccessResponse(request));
    }

    private static Response SuccessResponse(SaveStageResultCommand request) =>
        new()
        {
            Type = request.Request.Type,
            RequestId = request.Request.RequestId,
            Error = Error.Success,
            save_stage_result = new Response.SaveStageResult()
        };
}
