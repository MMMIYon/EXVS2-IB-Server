using Microsoft.EntityFrameworkCore;
using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Models.Cards.Message;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.MobileUser;

/// <summary>
/// Fills LoadCard.MobileUserGroup with the client-aligned 3×6 command message structure
/// (tags 31–33). Reads from the dedicated CommandMessageData table (Solo / Team / InstantTeam).
/// </summary>
public class LoadMessageCommand : ILoadCardMobileUserCommand
{
    private readonly ServerDbContext _context;

    public LoadMessageCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.MobileUserGroup mobileUserGroup)
    {
        var messageSetting = _context.MessageSettingDbSet
            .Include(x => x.CommandMessageDatas)
            .First(x => x.CardId == cardProfile.Id);

        mobileUserGroup.MuteFlag = messageSetting.AllowReceiveMessage;
        mobileUserGroup.MessagePosition = (CommandMessagePostion)messageSetting.MessagePosition;
        mobileUserGroup.CommandMessageAutoFlag = messageSetting.CommandMessageAutoFlag;

        mobileUserGroup.SoloCommandMessages = ToProto(FindOrDefault(messageSetting, CommandMessageMode.Solo));
        mobileUserGroup.TeamCommandMessages = ToProto(FindOrDefault(messageSetting, CommandMessageMode.Team));
        mobileUserGroup.InstantTeamCommandMessages = ToProto(FindOrDefault(messageSetting, CommandMessageMode.InstantTeam));
    }

    private static CommandMessageData FindOrDefault(Models.Cards.Settings.MessageSetting setting,
        CommandMessageMode mode)
    {
        return setting.CommandMessageDatas.FirstOrDefault(x => x.Mode == mode)
               ?? new CommandMessageData { Mode = mode };
    }

    private static Response.LoadCard.MobileUserGroup.CommandMessageData ToProto(CommandMessageData data)
    {
        return new Response.LoadCard.MobileUserGroup.CommandMessageData
        {
            StartMessageId = data.StartMessageId,
            StartMessageText = data.StartMessageText ?? string.Empty,
            UpMessageId = data.UpMessageId,
            UpMessageText = data.UpMessageText ?? string.Empty,
            DownMessageId = data.DownMessageId,
            DownMessageText = data.DownMessageText ?? string.Empty,
            LeftMessageId = data.LeftMessageId,
            LeftMessageText = data.LeftMessageText ?? string.Empty,
            RightMessageId = data.RightMessageId,
            RightMessageText = data.RightMessageText ?? string.Empty,
            EndMessageId = data.EndMessageId,
            EndMessageText = data.EndMessageText ?? string.Empty,
        };
    }
}
