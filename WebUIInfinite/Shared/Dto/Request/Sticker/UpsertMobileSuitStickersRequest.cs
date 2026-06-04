using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Request.Sticker;

public class UpsertMobileSuitStickersRequest : BasicCardRequest
{
    public List<StickerDto> MsStickerList { get; set; } = new();
}