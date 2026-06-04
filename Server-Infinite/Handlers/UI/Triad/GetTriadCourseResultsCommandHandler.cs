using MediatR;
using ServerInfinite.Mapper.Card.Triad;
using ServerInfinite.Persistence;
using ServerInfinite.Utils;
using WebUIInfinite.Shared.Dto.Triad;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.Triad;

public record GetTriadCourseResultsCommand(string AccessCode, string ChipId) : IRequest<TriadCourseOverallResult>;

public class GetTriadCourseResultsCommandHandler : IRequestHandler<GetTriadCourseResultsCommand, TriadCourseOverallResult>
{
    private readonly ServerDbContext _context;
    
    public GetTriadCourseResultsCommandHandler(ServerDbContext context)
    {
        _context = context;
    }
    
    public Task<TriadCourseOverallResult> Handle(GetTriadCourseResultsCommand request, CancellationToken cancellationToken)
    {
        var cardProfile = _context.CardProfiles
            .FirstOrDefault(x => x.AccessCode == request.AccessCode && x.ChipId == request.ChipId);
        
        if (cardProfile is null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }

        var triadCourseDatas = _context.TriadCourseDataDbSet
            .Where(x => x.CardProfile == cardProfile)
            .Select(cpuScenes => cpuScenes.ToTriadCourseResult())
            .ToList();

        var triadMiscInfo = _context.TriadMiscInfoDbSet
            .First(x => x.CardProfile == cardProfile);

        var triadCourseOverallResult = new TriadCourseOverallResult
        {
            TriadCourseResults = triadCourseDatas,
            CpuRibbons = ArrayUtil.FromString(triadMiscInfo.CpuRibbons)
        };
        
        return Task.FromResult(triadCourseOverallResult);
    }
}