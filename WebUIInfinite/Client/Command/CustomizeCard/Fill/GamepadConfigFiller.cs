using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class GamepadConfigFiller : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;

    public GamepadConfigFiller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var gamepadConfig = await _httpClient.GetFromJsonAsync<GamepadConfig>($"/ui/gamepad/getGamepadConfig/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        gamepadConfig.ThrowIfNull();

        customizeCardContext.GamepadConfig = gamepadConfig;
    }
}