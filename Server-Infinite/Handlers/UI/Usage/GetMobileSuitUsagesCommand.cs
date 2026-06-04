using MediatR;
using ServerInfinite.Mapper.Usage;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Usage;

namespace ServerInfinite.Handlers.UI.Usage;

public record GetMobileSuitUsagesCommand : IRequest<List<MobileSuitUsageDto>>;

public class GetMobileSuitUsagesCommandHandler : IRequestHandler<GetMobileSuitUsagesCommand, List<MobileSuitUsageDto>>
{
    private readonly ServerDbContext _context;

    public GetMobileSuitUsagesCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<List<MobileSuitUsageDto>> Handle(GetMobileSuitUsagesCommand request, CancellationToken cancellationToken)
    {
        var mobileSuitUsages = _context.MobileSuitUsageViews
            .Select(mobileSuitUsage => mobileSuitUsage.ToMobileSuitUsageDto())
            .ToList();
        
        return Task.FromResult(mobileSuitUsages);
    }
}