using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Preview;

public interface IGeneralPreviewService
{
    Dictionary<uint, GeneralPreview> CreateGeneralPreviewDictionary(List<GeneralPreview> generalPreviews);
    List<GeneralPreview> CreateSortedGeneralPreviewList(List<GeneralPreview> generalPreviews);
}