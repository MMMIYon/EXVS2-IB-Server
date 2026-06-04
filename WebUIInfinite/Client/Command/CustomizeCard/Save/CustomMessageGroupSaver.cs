using System.Net.Http.Json;
using Microsoft.Extensions.Localization;
using MudBlazor;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Client.Services;
using WebUIInfinite.Client.Services.Stamp;
using WebUIInfinite.Client.Validator;
using WebUIInfinite.Shared.Dto.Message;
using WebUIInfinite.Shared.Dto.Request;
using WebUIInfinite.Shared.Dto.Response;
using WebUIInfinite.Shared.Resources;

namespace WebUIInfinite.Client.Command.CustomizeCard.Save;

public class CustomMessageGroupSaver : ICustomizeCardContentSaver
{
    private readonly HttpClient _httpClient;
    private readonly INameValidator _nameValidator;
    private readonly IResponseSnackService _responseSnackService;
    private readonly IStringLocalizer<Resource> _localizer;

    public CustomMessageGroupSaver(HttpClient httpClient, INameValidator nameValidator, IResponseSnackService responseSnackService, IStringLocalizer<Resource> localizer)
    {
        _httpClient = httpClient;
        _nameValidator = nameValidator;
        _responseSnackService = responseSnackService;
        _localizer = localizer;
    }

    public async Task Save(CustomizeCardContext customizeCardContext, ProgressContext progressContext, ISnackbar snackbar,
        Action stateHasChanged)
    {
        var customMessageGroupSetting = customizeCardContext.CustomMessageGroupSetting;

        // Q2=A: new client-aligned 3 modes × 6 directions structure.
        var allMessageValid = AllMessageValid(customMessageGroupSetting.SoloGroup)
                              && AllMessageValid(customMessageGroupSetting.TeamGroup)
                              && AllMessageValid(customMessageGroupSetting.InstantTeamGroup);
        
        if (!allMessageValid)
        {
            _responseSnackService.ShowBasicResponseSnack(snackbar, new BasicResponse { Success = false }, _localizer["save_hint_commconfig"]);
            return;
        }
        
        progressContext.HideCommunicationMessageProgress = "visible";
        stateHasChanged.Invoke();
        
        var dto = new UpsertCustomMessagesRequest()
        {
            AccessCode = customizeCardContext.AccessCode,
            ChipId = customizeCardContext.ChipId,
            MessageSetting = customMessageGroupSetting
        };

        var response = await _httpClient.PostAsJsonAsync("/ui/message/upsertCustomMessages", dto);
        var result = await response.Content.ReadFromJsonAsync<BasicResponse>();
        result.ThrowIfNull();;

        _responseSnackService.ShowBasicResponseSnack(snackbar, result, _localizer["save_hint_commconfig"]);

        progressContext.HideCommunicationMessageProgress = "invisible";
        stateHasChanged.Invoke();
    }

    bool AllMessageValid(CustomMessageGroup customMessageGroup)
    {
        return SlotTextValid(customMessageGroup.StartMessage)
               && SlotTextValid(customMessageGroup.UpMessage)
               && SlotTextValid(customMessageGroup.DownMessage)
               && SlotTextValid(customMessageGroup.LeftMessage)
               && SlotTextValid(customMessageGroup.RightMessage)
               && SlotTextValid(customMessageGroup.EndMessage);
    }

    /// <summary>
    /// Only wire id 1 (customize text) validates MessageText. Id 0 = disable, id &gt; 1 = stamp image.
    /// </summary>
    bool SlotTextValid(CustomMessage message)
    {
        if (!CommunicationMessageStampIds.AllowsCustomText(message.UniqueMessageId))
        {
            return true;
        }

        return _nameValidator.ValidateCustomizeMessage(message.MessageText) is null;
    }
}