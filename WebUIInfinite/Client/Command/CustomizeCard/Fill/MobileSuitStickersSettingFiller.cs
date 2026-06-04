using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class MobileSuitStickersSettingFiller : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;
    
    public MobileSuitStickersSettingFiller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var msStickerDtos = await _httpClient.GetFromJsonAsync<List<StickerDto>>($"/ui/sticker/getMobileSuitStickers/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        msStickerDtos.ThrowIfNull();

        foreach (var dto in msStickerDtos)
        {
            dto.PoseIds ??= new List<uint>();
            dto.CostumeIds ??= new List<uint>();
            if (dto.PoseIds.Count == 0 && dto.PoseId > 0)
            {
                dto.PoseIds.Add(dto.PoseId);
            }
        }

        customizeCardContext.MobileSuitStickerSettings = msStickerDtos;
    }
}