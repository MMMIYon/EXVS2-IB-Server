using Riok.Mapperly.Abstractions;
using ServerInfinite.Views.Usage;
using WebUIInfinite.Shared.Dto.Usage;

namespace ServerInfinite.Mapper.Usage;

[Mapper]
public static partial class BurstUsageMapper
{
    public static partial BurstUsageDto ToBurstUsageDto(this BurstUsageView burstUsageView);
}