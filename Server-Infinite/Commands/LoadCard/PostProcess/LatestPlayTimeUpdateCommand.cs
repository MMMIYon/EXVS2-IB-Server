using nue.protocol.exvs;
using ServerInfinite.Models.Cards;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.LoadCard.PostProcess;

public class LatestPlayTimeUpdateCommand : ILoadCardPostProcessCommand
{
    private readonly ServerDbContext _context;
    
    public LatestPlayTimeUpdateCommand(ServerDbContext context)
    {
        _context = context;
    }

    public void PostProcess(CardProfile cardProfile, Request.LoadCard loadCardRequest)
    {
        cardProfile.LastPlayedAt = (ulong) DateTimeOffset.Now.ToUnixTimeSeconds();
        _context.SaveChanges();
    }
}