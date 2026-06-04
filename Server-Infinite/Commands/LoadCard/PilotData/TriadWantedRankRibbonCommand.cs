using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;
using ServerInfinite.Utils;
using WebUIInfinite.Shared.Dto.Enum;

namespace ServerInfinite.Commands.LoadCard.PilotData;

public class TriadWantedRankRibbonCommand : IPilotDataCommand
{
    private readonly ServerDbContext _context;

    public TriadWantedRankRibbonCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.PilotDataGroup pilotDataGroup)
    {
        var rankRecord = _context.WantedDefeatedCountViews
            .FirstOrDefault(x => x.CardId == cardProfile.Id && x.Rank <= TriadRankConstants.Top20);

        if (rankRecord is null)
        {
            return;
        }

        if (rankRecord.Rank == 1)
        {
            pilotDataGroup.CpuRibbons = pilotDataGroup.CpuRibbons.Concat(new [] { TriadRankConstants.WantedGold }).ToArray();
            return;
        }
        
        if (rankRecord.Rank == 2)
        {
            pilotDataGroup.CpuRibbons = pilotDataGroup.CpuRibbons.Concat(new [] { TriadRankConstants.WantedSilver }).ToArray();
            return;
        }
        
        if (rankRecord.Rank == 3)
        {
            pilotDataGroup.CpuRibbons = pilotDataGroup.CpuRibbons.Concat(new [] { TriadRankConstants.WantedBronze }).ToArray();
            return;
        }
        
        pilotDataGroup.CpuRibbons = pilotDataGroup.CpuRibbons.Concat(new [] { TriadRankConstants.WantedMetalic }).ToArray();
    }
}