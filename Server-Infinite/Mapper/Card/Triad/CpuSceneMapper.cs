using Riok.Mapperly.Abstractions;
using ServerInfinite.Models.Cards.Triad;
using WebUIInfinite.Shared.Dto.Triad;

namespace ServerInfinite.Mapper.Card.Triad;

[Mapper]
public static partial class CpuSceneMapper
{
    public static partial TriadCourseResult ToTriadCourseResult(this TriadCourseData triadCourseData);
}