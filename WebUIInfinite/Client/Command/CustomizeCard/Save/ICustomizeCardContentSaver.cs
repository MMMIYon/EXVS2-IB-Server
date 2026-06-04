using MudBlazor;
using WebUIInfinite.Client.Context.CustomizeCard;

namespace WebUIInfinite.Client.Command.CustomizeCard.Save;

public interface ICustomizeCardContentSaver
{
    Task Save(CustomizeCardContext customizeCardContext, ProgressContext progressContext, ISnackbar snackbar, Action stateHasChanged);
}