using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Shared.Dto.Training;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class TrainingProfileFiller : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;
    
    public TrainingProfileFiller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var trainingProfile = await _httpClient.GetFromJsonAsync<TrainingProfile>($"/ui/training/get/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        trainingProfile.ThrowIfNull();

        customizeCardContext.TrainingProfile = trainingProfile;
    }
}