using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Stamp;

public interface IStampDataService
{
    Task InitializeAsync();
    GeneralPreview? GetStampById(uint id);
    IReadOnlyList<GeneralPreview> GetStampsSortedById();
    IReadOnlyList<GeneralPreview> BuildCommunicationStampPickerList(string disableLabel, string customizeTextLabel);
    GeneralPreview? GetCommunicationPickerEntry(uint id, string disableLabel, string customizeTextLabel);
}
