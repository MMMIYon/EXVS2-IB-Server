using System.Net.Http.Json;
using Microsoft.Extensions.Localization;
using MudBlazor;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Client.Services;
using WebUIInfinite.Shared.Dto.Response;
using WebUIInfinite.Shared.Dto.Training;
using WebUIInfinite.Shared.Resources;

namespace WebUIInfinite.Client.Command.CustomizeCard.Save;

public class TrainingProfileSaver : ICustomizeCardContentSaver
{
    private readonly HttpClient _httpClient;
    private readonly IResponseSnackService _responseSnackService;
    private readonly IStringLocalizer<Resource> _localizer;

    public TrainingProfileSaver(HttpClient httpClient, IResponseSnackService responseSnackService, IStringLocalizer<Resource> localizer)
    {
        _httpClient = httpClient;
        _responseSnackService = responseSnackService;
        _localizer = localizer;
    }

    public async Task Save(CustomizeCardContext customizeCardContext, ProgressContext progressContext, ISnackbar snackbar, Action stateHasChanged)
    {
        progressContext.HideTrainingProfileProgress = "visible";
        stateHasChanged.Invoke();
        
        var dto = new UpdateTrainingProfileRequest()
        {
            AccessCode = customizeCardContext.AccessCode,
            ChipId = customizeCardContext.ChipId,
            TrainingProfile = customizeCardContext.TrainingProfile
        };
        
        var response = await _httpClient.PostAsJsonAsync("/ui/training/save", dto);
        var result = await response.Content.ReadFromJsonAsync<BasicResponse>();
        result.ThrowIfNull();
        
        _responseSnackService.ShowBasicResponseSnack(snackbar, result, _localizer["save_hint_training_profile"]);

        progressContext.HideTrainingProfileProgress = "invisible";
        stateHasChanged.Invoke();
    }
}