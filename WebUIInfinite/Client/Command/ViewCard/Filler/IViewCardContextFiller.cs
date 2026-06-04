using WebUIInfinite.Client.Context.ViewCard;

namespace WebUIInfinite.Client.Command.ViewCard.Filler;

public interface IViewCardContextFiller
{
    Task Fill(ViewCardContext viewCardContext);
}