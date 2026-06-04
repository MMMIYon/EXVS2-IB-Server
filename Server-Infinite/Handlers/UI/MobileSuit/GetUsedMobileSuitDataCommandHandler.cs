using MediatR;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Mapper.Card.MobileSuit;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Response;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.MobileSuit;

public record GetUsedMobileSuitDataCommand(string AccessCode, string ChipId) : IRequest<List<MsSkillGroup>>;

public class GetUsedMobileSuitDataCommandHandler : IRequestHandler<GetUsedMobileSuitDataCommand, List<MsSkillGroup>>
{
    private readonly ServerDbContext _context;
    
    public GetUsedMobileSuitDataCommandHandler(ServerDbContext context)
    {
        _context = context;
    }
    
    public Task<List<MsSkillGroup>> Handle(GetUsedMobileSuitDataCommand request, CancellationToken cancellationToken)
    {
        var cardProfile = _context.CardProfiles
            .Include(x => x.MobileSuits)
            .FirstOrDefault(x => x.AccessCode == request.AccessCode && x.ChipId == request.ChipId);

        if (cardProfile is null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }
        
        List<MsSkillGroup> result = new List<MsSkillGroup>();
        
        foreach (var msSkill in cardProfile.MobileSuits)
        {
            result.Add(msSkill.ToMSSkillGroupDto());
        }

        return Task.FromResult(result);
    }
}