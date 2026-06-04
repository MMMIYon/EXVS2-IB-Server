using Microsoft.Extensions.Localization;
using WebUIInfinite.Shared.Resources;

namespace WebUIInfinite.Client.Services.Stamp;

public static class CommunicationMessageStampDisplay
{
    public static string GetDisplayName(uint uniqueMessageId, IStampDataService stampDataService,
        IStringLocalizer<Resource> localizer)
    {
        return uniqueMessageId switch
        {
            CommunicationMessageStampIds.Disable => localizer["communication_stamp_disable"],
            CommunicationMessageStampIds.CustomizeText => localizer["communication_message_customize_text"],
            _ => stampDataService.GetStampById(uniqueMessageId)?.Value ?? localizer["unknown_stamp"],
        };
    }
}
