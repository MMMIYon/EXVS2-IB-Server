using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.PilotData;

public class TrainingDataCommand : IPilotDataCommand
{
    private readonly ServerDbContext _context;

    public TrainingDataCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.PilotDataGroup pilotDataGroup)
    {
        var trainingProfile = _context.TrainingProfileDbSet
            .First(x => x.CardProfile == cardProfile);
        
        pilotDataGroup.Training = new Response.LoadCard.PilotDataGroup.TrainingSettingGroup()
        {
            MstMobileSuitId = trainingProfile.MstMobileSuitId,
            BurstType = trainingProfile.BurstType,
            CpuLevel = trainingProfile.CpuLevel,
            ExBurstGauge = trainingProfile.ExBurstGauge,
            DamageDisplay = trainingProfile.DamageDisplay,
            CpuAutoGuard = trainingProfile.CpuAutoGuard,
            CommandGuideDisplay = trainingProfile.CommandGuideDisplay,
            // Client-aligned new optional fields (tags 8-11).
            Armor = trainingProfile.Armor,
            CpuAutoHeal = trainingProfile.CpuAutoHeal,
            ExOverLimit = trainingProfile.ExOverLimit,
            FastReload = trainingProfile.FastReload,
        };
    }
}