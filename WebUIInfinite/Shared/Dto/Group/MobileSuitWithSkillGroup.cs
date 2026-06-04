using WebUIInfinite.Shared.Dto.Common;
using WebUIInfinite.Shared.Dto.Response;

namespace WebUIInfinite.Shared.Dto.Group;

public class MobileSuitWithSkillGroup
{
    public MobileSuit MobileSuit { get; set; }
    public MsSkillGroup? SkillGroup { get; set; }
}