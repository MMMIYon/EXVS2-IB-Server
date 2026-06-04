using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Shared.Dto.Player;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class PlayerLevelProfileFiller : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;
    
    public PlayerLevelProfileFiller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var playerLevelProfile = await _httpClient.GetFromJsonAsync<PlayerLevelProfile>($"/ui/player-level/getPlayerLevelProfile/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        playerLevelProfile.ThrowIfNull();

        customizeCardContext.PlayerLevelProfile = playerLevelProfile;
    }
}