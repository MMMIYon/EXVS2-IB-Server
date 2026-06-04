using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Display;

public class DisplayOptionDataService : IDisplayOptionDataService
{
    private readonly HttpClient _client;
    private readonly ILogger<DisplayOptionDataService> _logger;
    
    private Dictionary<uint, IdValuePair> _displayOptions = new();
    
    private List<IdValuePair> _sortedDisplayOptionList = new();
    
    public DisplayOptionDataService(HttpClient client, ILogger<DisplayOptionDataService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        var displayOptionList = await _client.GetFromJsonAsync<List<IdValuePair>>("data/display/DisplayOptions.json");
        displayOptionList.ThrowIfNull();
        _displayOptions = displayOptionList.ToDictionary(pair => pair.Id);
        _sortedDisplayOptionList = displayOptionList.OrderBy(title => title.Id).ToList();
    }

    public IReadOnlyList<IdValuePair> GetDisplayOptionsSortedById()
    {
        return _sortedDisplayOptionList;
    }
}