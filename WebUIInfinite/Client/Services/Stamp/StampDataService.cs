using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Services.Preview;
using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Services.Stamp;

public class StampDataService : IStampDataService
{
    private readonly HttpClient _client;
    private readonly IGeneralPreviewService _generalPreviewService;
    private readonly ILogger<StampDataService> _logger;

    private Dictionary<uint, GeneralPreview> _stamps = new();
    private List<GeneralPreview> _sortedStampsList = new();

    public StampDataService(HttpClient client, IGeneralPreviewService generalPreviewService, ILogger<StampDataService> logger)
    {
        _client = client;
        _generalPreviewService = generalPreviewService;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        var stampList = await _client.GetFromJsonAsync<List<GeneralPreview>>("data/messages/Stamps.json");
        stampList.ThrowIfNull();

        // Skip 0=None and 1=CustomizeText (picker injects those). Stamp rows are 10001+ in JSON.
        var remapped = stampList
            .Where(s => s.Id > 1)
            .Select(s => new GeneralPreview
            {
                Id = CommunicationMessageStampIds.ToWireStampId(s.Id),
                Value = s.Value,
                Existence = s.Existence,
                Category = s.Category,
                Clues = s.Clues,
                Clues2 = s.Clues2,
            })
            .ToList();

        _stamps = _generalPreviewService.CreateGeneralPreviewDictionary(remapped);
        _sortedStampsList = _generalPreviewService.CreateSortedGeneralPreviewList(remapped);
    }

    public GeneralPreview? GetStampById(uint id) => _stamps.GetValueOrDefault(id);

    public IReadOnlyList<GeneralPreview> GetStampsSortedById() => _sortedStampsList;

    public IReadOnlyList<GeneralPreview> BuildCommunicationStampPickerList(string disableLabel, string customizeTextLabel)
    {
        var list = new List<GeneralPreview>
        {
            new()
            {
                Id = CommunicationMessageStampIds.Disable,
                Value = disableLabel,
                Existence = "VS2",
            },
            new()
            {
                Id = CommunicationMessageStampIds.CustomizeText,
                Value = customizeTextLabel,
                Existence = "VS2",
            },
        };
        list.AddRange(_sortedStampsList);
        return list;
    }

    public GeneralPreview? GetCommunicationPickerEntry(uint id, string disableLabel, string customizeTextLabel)
    {
        if (id == CommunicationMessageStampIds.Disable)
        {
            return new GeneralPreview { Id = id, Value = disableLabel, Existence = "VS2" };
        }

        if (id == CommunicationMessageStampIds.CustomizeText)
        {
            return new GeneralPreview { Id = id, Value = customizeTextLabel, Existence = "VS2" };
        }

        return GetStampById(id);
    }
}
