using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Request.Sticker;

public class UpdateDefaultStickerRequest : BasicCardRequest
{
    public StickerDto StickerDto { get; set; } = new();
}