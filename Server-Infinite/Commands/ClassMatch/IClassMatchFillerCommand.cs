using nue.protocol.exvs;

namespace ServerInfinite.Commands.ClassMatch;

public interface IClassMatchFillerCommand
{
    void Fill(Response.LoadClassMatch loadClassMatchResponse);
}