using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Request;

public class UpdateCpuTriadPartnerRequest : BasicCardRequest
{
    public CpuTriadPartner CpuTriadPartner { get; set; } = new();
}