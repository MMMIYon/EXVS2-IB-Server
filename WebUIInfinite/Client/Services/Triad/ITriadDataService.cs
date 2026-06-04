using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Triad;

public interface ITriadDataService
{
    public Task InitializeAsync();
    public IReadOnlyList<IdValuePair> GetSortedTriadSkillList();
    public IdValuePair? GetTriadSkill(uint id);
    public IReadOnlyList<GeneralPreview> GetTriadTeamBackgroundSortedById();
    public GeneralPreview? GetTriadTeamBackgroundById(uint id);
}