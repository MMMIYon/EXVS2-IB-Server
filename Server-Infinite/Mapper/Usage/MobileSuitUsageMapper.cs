using Riok.Mapperly.Abstractions;
using ServerInfinite.Views.Usage;
using WebUIInfinite.Shared.Dto.Usage;

namespace ServerInfinite.Mapper.Usage;

[Mapper]
public static partial class MobileSuitUsageMapper
{
    public static partial MobileSuitUsageDto ToMobileSuitUsageDto(this MobileSuitUsageView mobileSuitUsageView);
}