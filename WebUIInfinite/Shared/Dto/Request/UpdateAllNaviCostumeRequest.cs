using WebUIInfinite.Shared.Dto.Common;

namespace WebUIInfinite.Shared.Dto.Request;

public class UpdateAllNaviCostumeRequest : BasicCardRequest
{
    public List<Navi> Navis { get; set; } = new();
}