using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Client.Services.Mastery;
using WebUIInfinite.Client.Services.MS;
using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Dto.Group;
using WebUIInfinite.Shared.Dto.Response;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class MsSkillGroupAggregator : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;
    private IMobileSuitDataService _mobileSuitDataService;
    private IFamiliarityDataService _iFamiliarityDataService;

    public MsSkillGroupAggregator(HttpClient httpClient, IMobileSuitDataService mobileSuitDataService, IFamiliarityDataService iFamiliarityDataService)
    {
        _httpClient = httpClient;
        _mobileSuitDataService = mobileSuitDataService;
        _iFamiliarityDataService = iFamiliarityDataService;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var msSkillGroup = await _httpClient.GetFromJsonAsync<List<MsSkillGroup>>($"/ui/mobileSuit/getUsedMobileSuitData/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        msSkillGroup.ThrowIfNull();

        customizeCardContext.MsSkillGroups = msSkillGroup;
        
        customizeCardContext.AggregetedMobileSuits = new();
        
        _mobileSuitDataService.GetWritableMobileSuitSortedById()
            .ForEach(ms => customizeCardContext.AggregetedMobileSuits.Add((MobileSuit) ms.Clone()));
        
        customizeCardContext.AggregetedMobileSuits
            .ForEach(mobileSuit =>
            {
                if (mobileSuit.Id == 0)
                {
                    mobileSuit.MasteryPoint = -1;
                    return;
                }
                    
                var msData = customizeCardContext.MsSkillGroups
                    .FirstOrDefault(msSkill => msSkill.MstMobileSuitId == mobileSuit.Id);

                if (msData is null)
                {
                    mobileSuit.MasteryPoint = 0;
                    mobileSuit.MasteryDomain = _iFamiliarityDataService.GetMsFamiliaritySortedById().First();
                    return;
                }

                mobileSuit.MasteryPoint = (int) msData.MsUsedNum;
                mobileSuit.MasteryDomain = _iFamiliarityDataService.GetMsFamiliaritySortedById()
                    .Reverse()
                    .First(msFamiliarity => msData.MsUsedNum >= msFamiliarity.MinimumPoint);
            });
        
        customizeCardContext.MobileSuitWithSkillGroups = customizeCardContext.AggregetedMobileSuits
            .Select(x => new MobileSuitWithSkillGroup { MobileSuit = x }).ToList();
    }
}