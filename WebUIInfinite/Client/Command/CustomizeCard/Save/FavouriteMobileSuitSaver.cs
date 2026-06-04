using System.Net.Http.Json;
using Microsoft.Extensions.Localization;
using MudBlazor;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Client.Services;
using WebUIOVer.Shared.Dto.Common;
using WebUIInfinite.Shared.Dto.Request;
using WebUIInfinite.Shared.Dto.Response;
using WebUIInfinite.Shared.Resources;

namespace WebUIInfinite.Client.Command.CustomizeCard.Save;

public class FavouriteMobileSuitSaver : ICustomizeCardContentSaver
{
    private readonly HttpClient _httpClient;
    private readonly IResponseSnackService _responseSnackService;
    private readonly IStringLocalizer<Resource> _localizer;

    public FavouriteMobileSuitSaver(HttpClient httpClient, IResponseSnackService responseSnackService, IStringLocalizer<Resource> localizer)
    {
        _httpClient = httpClient;
        _responseSnackService = responseSnackService;
        _localizer = localizer;
    }

    public async Task Save(CustomizeCardContext customizeCardContext, ProgressContext progressContext, ISnackbar snackbar,
        Action stateHasChanged)
    {
        progressContext.HideFavMsProgress = "visible";
        stateHasChanged.Invoke();

        var dto = new UpdateAllFavouriteMsRequest()
        {
            AccessCode = customizeCardContext.AccessCode,
            ChipId = customizeCardContext.ChipId,
            FavouriteMsList = customizeCardContext.FavouriteMsCollection.ToList()
        };
        
        var response = await _httpClient.PostAsJsonAsync("/ui/mobileSuit/updateAllFavouriteMs", dto);
        var result = await response.Content.ReadFromJsonAsync<BasicResponse>();
        result.ThrowIfNull();

        _responseSnackService.ShowBasicResponseSnack(snackbar, result, _localizer["save_hint_favms"]);

        progressContext.HideFavMsProgress = "invisible";
        stateHasChanged.Invoke();
    }
}