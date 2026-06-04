using nue.protocol.exvs;
using ServerInfinite.Mapper.Card.Triad;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.PilotData;

public class TriadCourseDataCommand : IPilotDataCommand
{
    private readonly ServerDbContext _context;

    public TriadCourseDataCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void Fill(CardProfile cardProfile, Response.LoadCard.PilotDataGroup pilotDataGroup)
    {
        _context.TriadCourseDataDbSet
            .Where(x => x.CardProfile == cardProfile)
            .ToList()
            .ForEach(triadCourseData => pilotDataGroup.CpuScenes.Add(triadCourseData.ToCpuSceneData()));
    }
}