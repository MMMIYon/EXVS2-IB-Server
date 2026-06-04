using MediatR;
using ServerInfinite.Mapper.Card.Training;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Training;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.Training;

public record GetTrainingProfileCommand(string AccessCode, string ChipId) : IRequest<TrainingProfile>;

public class GetTrainingProfileCommandHandler: IRequestHandler<GetTrainingProfileCommand, TrainingProfile>
{
    private readonly ServerDbContext _context;
    
    public GetTrainingProfileCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<TrainingProfile> Handle(GetTrainingProfileCommand request, CancellationToken cancellationToken)
    {
        var cardProfile = _context.CardProfiles
            .FirstOrDefault(x => x.AccessCode == request.AccessCode && x.ChipId == request.ChipId);

        if (cardProfile is null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }

        var trainingProfile = _context.TrainingProfileDbSet
            .First(x => x.CardProfile == cardProfile)
            .ToTrainingProfile();
        
        return Task.FromResult(trainingProfile);
    }
}