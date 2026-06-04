using nue.protocol.exvs;
using ServerInfinite.Constants.ClassMatch;

namespace ServerInfinite.Commands.ClassMatch;

public class AceClassChangePercentageCommand : IClassMatchFillerCommand
{
    public void Fill(Response.LoadClassMatch loadClassMatchResponse)
    {
        loadClassMatchResponse.ClassChangePercentages.Add(new Response.LoadClassMatch.ClassChangePercentage()
        {
            TeamType = ClassTeamType.SoloOnlineClass,
            ClassId = RankType.Ace,
            PromotePercentage = 10,
            RelagatePercentage = 90
        });
        
        loadClassMatchResponse.ClassChangePercentages.Add(new Response.LoadClassMatch.ClassChangePercentage()
        {
            TeamType = ClassTeamType.TeamOnlineClass,
            ClassId = RankType.Ace,
            PromotePercentage = 10,
            RelagatePercentage = 90
        });
    }
}