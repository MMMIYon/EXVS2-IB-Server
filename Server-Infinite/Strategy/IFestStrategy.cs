using nue.protocol.exvs;

namespace ServerInfinite.Strategy;

public interface IFestStrategy
{
    Response.LoadGameData.XrossFesSetting determine();
}