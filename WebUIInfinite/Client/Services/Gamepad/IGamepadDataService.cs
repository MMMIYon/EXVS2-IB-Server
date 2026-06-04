using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Gamepad;

public interface IGamepadDataService
{
    public Task InitializeAsync();
    public IReadOnlyList<IdValuePair> GetSortedGamepadOptionList();
}