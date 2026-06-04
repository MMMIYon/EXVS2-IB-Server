using System.Net.Http.Json;
using Throw;
using WebUIInfinite.Client.Context.CustomizeCard;
using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public class CpuTriadPartnerFiller : ICustomizeCardContextFiller
{
    private HttpClient _httpClient;

    public CpuTriadPartnerFiller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fill(CustomizeCardContext customizeCardContext)
    {
        var cpuTriadPartner = await _httpClient.GetFromJsonAsync<CpuTriadPartner>($"/ui/triad/getCpuTriadPartner/{customizeCardContext.AccessCode}/{customizeCardContext.ChipId}");
        cpuTriadPartner.ThrowIfNull();

        customizeCardContext.CpuTriadPartner = cpuTriadPartner;
    }
}