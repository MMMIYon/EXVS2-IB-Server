// CpuTriadPartner mapping is paired with the disabled WebUI handlers in
// ServerInfinite.Handlers.UI.Triad. Re-enable when the Triad CPU partner feature
// returns or when WebUI is reactivated against the new schema.
#if FALSE
using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Triad;
using WebUIInfinite.Shared.Dto.Common;

namespace ServerInfinite.Mapper.Card.Triad;

[Mapper]
public static partial class CpuTriadPartnerMapper
{
    [MapProperty(nameof(TriadPartner.MstMobileSuitId), nameof(CpuTriadPartner.MobileSuitId))]
    [MapProperty(nameof(TriadPartner.MsSkill1), nameof(CpuTriadPartner.Skill1))]
    [MapProperty(nameof(TriadPartner.MsSkill2), nameof(CpuTriadPartner.Skill2))]
    public static partial CpuTriadPartner ToCpuTriadPartner(this TriadPartner triadPartner);
}
#endif