using MediatR;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Models.Cards.Message;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Enum;
using WebUIInfinite.Shared.Dto.Message;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.Message;

public record GetCustomMessageGroupSettingCommand(string AccessCode, string ChipId) : IRequest<CustomMessageGroupSetting>;

/// <summary>
/// Reads the per-card command message setting from the new client-aligned 3×6 table (Q2=A).
/// Missing rows are materialised on-the-fly with default values so older cards keep working
/// even before they reach SaveChanges.
/// </summary>
public class GetCustomMessageGroupSettingCommandHandler
    : IRequestHandler<GetCustomMessageGroupSettingCommand, CustomMessageGroupSetting>
{
    private readonly ServerDbContext _context;

    public GetCustomMessageGroupSettingCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<CustomMessageGroupSetting> Handle(GetCustomMessageGroupSettingCommand request,
        CancellationToken cancellationToken)
    {
        var cardProfile = _context.CardProfiles
            .FirstOrDefault(x => x.AccessCode == request.AccessCode && x.ChipId == request.ChipId);

        if (cardProfile is null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }

        var messageSetting = _context.MessageSettingDbSet
            .Include(x => x.CommandMessageDatas)
            .First(x => x.CardId == cardProfile.Id);

        return Task.FromResult(new CustomMessageGroupSetting
        {
            MessagePosition = (MessagePosition)messageSetting.MessagePosition,
            AllowReceiveMessage = messageSetting.AllowReceiveMessage,
            CommandMessageAutoFlag = messageSetting.CommandMessageAutoFlag,
            SoloGroup = ToCustomMessageGroup(FindOrDefault(messageSetting, CommandMessageMode.Solo)),
            TeamGroup = ToCustomMessageGroup(FindOrDefault(messageSetting, CommandMessageMode.Team)),
            InstantTeamGroup = ToCustomMessageGroup(FindOrDefault(messageSetting, CommandMessageMode.InstantTeam)),
        });
    }

    private static CommandMessageData FindOrDefault(Models.Cards.Settings.MessageSetting messageSetting,
        CommandMessageMode mode)
    {
        return messageSetting.CommandMessageDatas.FirstOrDefault(x => x.Mode == mode)
               ?? new CommandMessageData { Mode = mode };
    }

    private static CustomMessageGroup ToCustomMessageGroup(CommandMessageData data)
    {
        return new CustomMessageGroup
        {
            StartMessage = new CustomMessage { MessageText = data.StartMessageText, UniqueMessageId = data.StartMessageId },
            UpMessage = new CustomMessage { MessageText = data.UpMessageText, UniqueMessageId = data.UpMessageId },
            DownMessage = new CustomMessage { MessageText = data.DownMessageText, UniqueMessageId = data.DownMessageId },
            LeftMessage = new CustomMessage { MessageText = data.LeftMessageText, UniqueMessageId = data.LeftMessageId },
            RightMessage = new CustomMessage { MessageText = data.RightMessageText, UniqueMessageId = data.RightMessageId },
            EndMessage = new CustomMessage { MessageText = data.EndMessageText, UniqueMessageId = data.EndMessageId },
        };
    }
}
