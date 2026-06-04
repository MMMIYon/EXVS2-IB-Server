using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Dto.Message;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class CustomMessageGroupFiller : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;
    
    public CustomMessageGroupFiller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var customMessageGroupSetting = await _httpClient.GetFromJsonAsync<CustomMessageGroupSetting>($"/ui/message/getCustomMessageGroupSetting/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        customMessageGroupSetting.ThrowIfNull();

        customizeCardContext.CustomMessageGroupSetting = customMessageGroupSetting;
    }
}