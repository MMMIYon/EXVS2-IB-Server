using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Display;

public interface IDisplayOptionDataService
{
    public Task InitializeAsync();
    public IReadOnlyList<IdValuePair> GetDisplayOptionsSortedById();
}