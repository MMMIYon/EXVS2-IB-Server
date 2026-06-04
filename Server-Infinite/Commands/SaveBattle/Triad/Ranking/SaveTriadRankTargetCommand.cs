using ServerInfinite.Context.Battle;
using ServerInfinite.Models.Cards;
using ServerInfinite.Models.Cards.Triad.Ranking;
using ServerInfinite.Models.Config;
using ServerInfinite.Persistence;

namespace ServerInfinite.Commands.SaveBattle.Triad.Ranking;

public class SaveTriadRankTargetCommand : ISaveBattleDataCommand
{
    private readonly ServerDbContext _context;
    private readonly uint _year;
    private readonly uint _month;
    
    public SaveTriadRankTargetCommand(ServerDbContext context, uint year, uint month)
    {
        _context = context;
        _year = year;
        _month = month;
    }

    public void Save(CardProfile cardProfile, BattleResultContext battleResultContext)
    {
        var isWin = battleResultContext.CommonDomain.IsWin;

        if (!isWin)
        {
            return;
        }
        
        var triadInfoDomain = battleResultContext.TriadInfoDomain;
        
        var defeatedCount = triadInfoDomain.Foes
            .Count(x => x.TargetMsFlag == 1 && x.DownNum > 0);

        if (defeatedCount == 0)
        {
            return;
        }
        
        var targetRecord = _context.TriadTargetDefeatedCountDbSet
            .FirstOrDefault(x => x.CardProfile == cardProfile && x.Year == _year && x.Month == _month);
        
        if (targetRecord is null)
        {
            var triadTargetRecord = new TriadTargetDefeatedCount()
            {
                CardProfile = cardProfile,
                Year = _year,
                Month = _month,
                DestroyCount = (uint) defeatedCount
            };
            
            _context.Add(triadTargetRecord);
            _context.SaveChanges();
            return;
        }

        targetRecord.DestroyCount += (uint)defeatedCount;
        _context.SaveChanges();
    }
}