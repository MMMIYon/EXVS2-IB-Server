using WebUIInfinite.Shared.Dto.Triad;

namespace WebUIInfinite.Client.Services.Triad;

public interface ITriadStageDataService
{
    public Task InitializeAsync();
    public List<TriadCourseConfig> GetTriadCourseConfigs();
}