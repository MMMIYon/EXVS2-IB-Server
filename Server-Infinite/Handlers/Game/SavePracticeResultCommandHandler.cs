using MediatR;
using nue.protocol.exvs;
using ServerInfinite.Commands.Common;
using ServerInfinite.Commands.SaveBattle;
using ServerInfinite.Commands.SaveBattle.Common;
using ServerInfinite.Mapper.Context;
using ServerInfinite.Persistence;

namespace ServerInfinite.Handlers.Game;

public record SavePracticeResultCommand(Request Request) : IRequest<Response>;

public class SavePracticeResultCommandHandler : IRequestHandler<SavePracticeResultCommand, Response>
{
    private readonly ServerDbContext _context;

    public SavePracticeResultCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<Response> Handle(SavePracticeResultCommand request, CancellationToken cancellationToken)
    {
        var saveRequest = request.Request.save_practice_result;
        var cardProfile = _context.CardProfiles
            .FirstOrDefault(x => x.SessionId == saveRequest.SessionId && x.Id == saveRequest.PilotId);

        if (cardProfile == null)
        {
            return Task.FromResult(SuccessResponse(request));
        }

        var playResultGroup = saveRequest.Result;
        var battleResultContext = playResultGroup.ToBattleResultContext();

        var saveBattleDataCommands = new List<ISaveBattleDataCommand>
        {
            new SavePlayerLevelCommand(_context),
            new SaveNaviCommand(_context),
            new SaveMobileSuitMasteryCommand(_context),
        };

        saveBattleDataCommands.ForEach(command => command.Save(cardProfile, battleResultContext));
        new SaveQuickStartSettingCommand(_context).Save(cardProfile, playResultGroup.QuickStartInfo);

        _context.SaveChanges();

        return Task.FromResult(SuccessResponse(request));
    }

    private static Response SuccessResponse(SavePracticeResultCommand request) =>
        new()
        {
            Type = request.Request.Type,
            RequestId = request.Request.RequestId,
            Error = Error.Success,
            save_practice_result = new Response.SavePracticeResult()
        };
}
