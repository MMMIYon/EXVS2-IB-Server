using System.Linq.Expressions;
using WebUIInfinite.Shared.Dto.Group;

namespace WebUIInfinite.Client.Services.Selector;

public interface ISelectorService
{
    public Expression<Func<NaviWithNavigatorGroup, string>> GetNaviSeriesSelector();
    public Expression<Func<NaviWithNavigatorGroup, string>> GetNaviSeiyuuSelector();
    public Expression<Func<MobileSuitWithSkillGroup, string>> GetMsPilotSelector();
}