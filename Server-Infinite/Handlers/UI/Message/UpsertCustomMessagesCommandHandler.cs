using MediatR;
using Microsoft.EntityFrameworkCore;
using ServerInfinite.Models.Cards.Message;
using ServerInfinite.Persistence;
using WebUIInfinite.Shared.Dto.Message;
using WebUIInfinite.Shared.Dto.Request;
using WebUIInfinite.Shared.Dto.Response;
using WebUIInfinite.Shared.Exception;

namespace ServerInfinite.Handlers.UI.Message;

public record UpsertCustomMessagesCommand(UpsertCustomMessagesRequest Request) : IRequest<BasicResponse>;

/// <summary>
/// Persists the WebUI-edited command message setting to the new client-aligned 3×6 table (Q2=A).
/// If a per-mode CommandMessageData row is missing it gets created on the fly.
/// </summary>
public class UpsertCustomMessagesCommandHandler : IRequestHandler<UpsertCustomMessagesCommand, BasicResponse>
{
    private readonly ServerDbContext _context;

    public UpsertCustomMessagesCommandHandler(ServerDbContext context)
    {
        _context = context;
    }

    public Task<BasicResponse> Handle(UpsertCustomMessagesCommand request, CancellationToken cancellationToken)
    {
        var updateRequest = request.Request;

        var cardProfile = _context.CardProfiles
            .FirstOrDefault(x => x.AccessCode == updateRequest.AccessCode && x.ChipId == updateRequest.ChipId);

        if (cardProfile is null)
        {
            throw new InvalidCardDataException("Card Profile is invalid");
        }

        var requestMessageSetting = updateRequest.MessageSetting;

        var playerMessageSetting = _context.MessageSettingDbSet
            .Include(x => x.CommandMessageDatas)
            .First(x => x.CardId == cardProfile.Id);

        playerMessageSetting.MessagePosition = (uint)requestMessageSetting.MessagePosition;
        playerMessageSetting.AllowReceiveMessage = requestMessageSetting.AllowReceiveMessage;
        playerMessageSetting.CommandMessageAutoFlag = requestMessageSetting.CommandMessageAutoFlag;

        UpsertGroup(playerMessageSetting, CommandMessageMode.Solo, requestMessageSetting.SoloGroup);
        UpsertGroup(playerMessageSetting, CommandMessageMode.Team, requestMessageSetting.TeamGroup);
        UpsertGroup(playerMessageSetting, CommandMessageMode.InstantTeam, requestMessageSetting.InstantTeamGroup);

        _context.SaveChanges();

        return Task.FromResult(new BasicResponse { Success = true });
    }

    private void UpsertGroup(Models.Cards.Settings.MessageSetting setting,
        CommandMessageMode mode, CustomMessageGroup source)
    {
        var target = setting.CommandMessageDatas.FirstOrDefault(x => x.Mode == mode)
                     ?? _context.CommandMessageDataDbSet
                         .FirstOrDefault(x => x.MessageSettingId == setting.MessageSettingId && x.Mode == mode);
        if (target is null)
        {
            target = new CommandMessageData
            {
                MessageSettingId = setting.MessageSettingId,
                Mode = mode,
            };
            _context.CommandMessageDataDbSet.Add(target);
            setting.CommandMessageDatas.Add(target);
        }

        target.StartMessageText = source.StartMessage.MessageText;
        target.StartMessageId = source.StartMessage.UniqueMessageId;
        target.UpMessageText = source.UpMessage.MessageText;
        target.UpMessageId = source.UpMessage.UniqueMessageId;
        target.DownMessageText = source.DownMessage.MessageText;
        target.DownMessageId = source.DownMessage.UniqueMessageId;
        target.LeftMessageText = source.LeftMessage.MessageText;
        target.LeftMessageId = source.LeftMessage.UniqueMessageId;
        target.RightMessageText = source.RightMessage.MessageText;
        target.RightMessageId = source.RightMessage.UniqueMessageId;
        target.EndMessageText = source.EndMessage.MessageText;
        target.EndMessageId = source.EndMessage.UniqueMessageId;
    }
}
