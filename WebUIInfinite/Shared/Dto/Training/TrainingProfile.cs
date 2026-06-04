using WebUIInfinite.Shared.Dto.Enum;

namespace WebUIInfinite.Shared.Dto.Training;

public class TrainingProfile
{
    public uint MstMobileSuitId { get; set; } = 0;
    public BurstType BurstType { get; set; } = 0;
    public uint CpuLevel { get; set; } = 0;
    public uint ExBurstGauge { get; set; } = 0;
    public bool DamageDisplay { get; set; } = true;
    public bool CpuAutoGuard { get; set; } = true;
    // Client-aligned: command_guide_display switched from bool to uint
    // (0 = None, 1 = Arcade button, 2 = Operation name).
    public uint CommandGuideDisplay { get; set; } = 0;
    // Client-aligned new optional fields (TrainingSettingGroup tags 8-11).
    // Armor is a 5-step menu (0=100%, 1=50%, 2=33%, 3=25%, 4=20%).
    public uint Armor { get; set; } = 0;
    public bool CpuAutoHeal { get; set; } = false;
    public bool ExOverLimit { get; set; } = false;
    public bool FastReload { get; set; } = false;
}