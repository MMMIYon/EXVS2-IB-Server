using MediatR;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Request;
using WebUIInfinite.Shared.Dto.Response;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.Gamepad;

public record UpsertGamepadConfigCommand(UpsertGamepadConfigRequest Request) : IRequest<BasicResponse>;

public class UpsertGamepadConfigCommandHandler : IRequestHandler<UpsertGamepadConfigCommand, BasicResponse>
{
    private readonly ServerDbContext _context;
    
    public UpsertGamepadConfigCommandHandler(ServerDbContext context)
    {
        _context = context;
    }
    
    public Task<BasicResponse> Handle(UpsertGamepadConfigCommand request, CancellationToken cancellationToken)
    {
        var updateRequest = request.Request;
        
        var cardProfile = _context.CardProfiles
            .Include(x => x.GamepadSetting)
            .FirstOrDefault(x => x.AccessCode == updateRequest.AccessCode && x.ChipId == updateRequest.ChipId);

        if (cardProfile is null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }

        cardProfile.GamepadSetting.AKey = updateRequest.GamepadConfig.AKey;
        cardProfile.GamepadSetting.BKey = updateRequest.GamepadConfig.BKey;
        cardProfile.GamepadSetting.XKey = updateRequest.GamepadConfig.XKey;
        cardProfile.GamepadSetting.YKey = updateRequest.GamepadConfig.YKey;
        cardProfile.GamepadSetting.LbKey = updateRequest.GamepadConfig.LbKey;
        cardProfile.GamepadSetting.RbKey = updateRequest.GamepadConfig.RbKey;
        cardProfile.GamepadSetting.LtKey = updateRequest.GamepadConfig.LtKey;
        cardProfile.GamepadSetting.RtKey = updateRequest.GamepadConfig.RtKey;
        cardProfile.GamepadSetting.LsbKey = updateRequest.GamepadConfig.LsbKey;
        cardProfile.GamepadSetting.RsbKey = updateRequest.GamepadConfig.RsbKey;
        cardProfile.GamepadSetting.GamePadStyle = updateRequest.GamepadConfig.GamePadStyle;
        cardProfile.GamepadSetting.CommandDispConfig = updateRequest.GamepadConfig.CommandDispConfig;

        _context.SaveChanges();

        return Task.FromResult(new BasicResponse
        {
            Success = true
        });
    }
}