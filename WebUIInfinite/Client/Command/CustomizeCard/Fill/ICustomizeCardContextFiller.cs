using WebUIInfinite.Client.Context.CustomizeCard;

namespace WebUIInfinite.Client.Command.CustomizeCard.Fill;

public interface ICustomizeCardContextFiller
{
    Task Fill(CustomizeCardContext customizeCardContext);
}