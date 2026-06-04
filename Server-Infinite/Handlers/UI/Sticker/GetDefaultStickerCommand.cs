using MediatR;
using ServerInfinite.Mapper.Card.Sticker;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.Sticker;

public record GetDefaultStickerCommand(string AccessCode, string ChipId) : IRequest<StickerDto>;
public class GetDefaultStickerCommandHandler : IRequestHandler<GetDefaultStickerCommand, StickerDto>
{
    private readonly ServerDbContext _context;

    public GetDefaultStickerCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<StickerDto> Handle(GetDefaultStickerCommand request, CancellationToken cancellationToken)
    {
        var cardProfile = _context.CardProfiles
            .FirstOrDefault(x => x.AccessCode == request.AccessCode && x.ChipId == request.ChipId);

        if (cardProfile == null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }

        var defaultStickerProfile = _context.DefaultStickerProfileDbSet
            .First(x => x.CardProfile == cardProfile);
        
        return Task.FromResult(defaultStickerProfile.ToStickerDto());
    }
}