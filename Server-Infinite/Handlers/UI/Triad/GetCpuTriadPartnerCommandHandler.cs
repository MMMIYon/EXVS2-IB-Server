// Triad CPU partner editing has been removed from the new client schema.
// The handler is preserved (commented) so the WebUI flow can be restored later by
// re-enabling the block. See also: TriadController GetCpuTriadPartner / UpdateCpuTriadPartner,
// CpuTriadPartnerMapper, UpdateCpuTriadPartnerCommandHandler.
#if FALSE
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Mapper.Card.Triad;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.Triad;

public record GetCpuTriadPartnerCommand(string AccessCode, string ChipId) : IRequest<CpuTriadPartner>;

public class GetCpuTriadPartnerCommandHandler : IRequestHandler<GetCpuTriadPartnerCommand, CpuTriadPartner>
{
    private readonly ServerDbContext _context;

    public GetCpuTriadPartnerCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<CpuTriadPartner> Handle(GetCpuTriadPartnerCommand request, CancellationToken cancellationToken)
    {
        var cardProfile = _context.CardProfiles
            .Include(x => x.TriadPartner)
            .FirstOrDefault(x => x.AccessCode == request.AccessCode && x.ChipId == request.ChipId);

        if (cardProfile == null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }

        return Task.FromResult(cardProfile.TriadPartner.ToCpuTriadPartner());
    }
}
#endif