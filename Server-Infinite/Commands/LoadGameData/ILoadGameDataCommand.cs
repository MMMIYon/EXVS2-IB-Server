using nue.protocol.exvs;

namespace ServerInfinite.Commands.LoadGameData;

public interface ILoadGameDataCommand
{
    void Fill(Response.LoadGameData loadGameData);
}