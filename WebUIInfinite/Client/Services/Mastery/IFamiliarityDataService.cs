using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Mastery;

public interface IFamiliarityDataService
{
    public Task InitializeAsync();
    public IReadOnlyList<Familiarity> GetNaviFamiliaritySortedById();
    public IReadOnlyList<Familiarity> GetMsFamiliaritySortedById();
    Familiarity ResolveMsFamiliarity(uint masteryPoints);
}