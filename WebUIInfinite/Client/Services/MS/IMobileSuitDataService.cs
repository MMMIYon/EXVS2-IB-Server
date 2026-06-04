using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.MS;

public interface IMobileSuitDataService
{
    public Task InitializeAsync();
    public MobileSuit? GetMobileSuitById(uint id);
    public IReadOnlyList<MobileSuit> GetMobileSuitSortedById();
    public List<MobileSuit> GetWritableMobileSuitSortedById();
}