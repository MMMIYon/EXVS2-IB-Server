using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class DefaultStickerSettingFiller : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;
    
    public DefaultStickerSettingFiller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var defaultSticker = await _httpClient.GetFromJsonAsync<StickerDto>($"/ui/sticker/getDefaultSticker/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        defaultSticker.ThrowIfNull();

        defaultSticker.PoseIds ??= new List<uint>();
        defaultSticker.CostumeIds ??= new List<uint>();

        customizeCardContext.DefaultStickerSetting = defaultSticker;
    }
}