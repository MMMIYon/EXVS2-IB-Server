using MudBlazor;
using WebUIInfinite.Shared.Dto.Response;

namespace WebUIInfinite.Client.Services;

public interface IResponseSnackService
{
    void ShowBasicResponseSnack(ISnackbar snackbar, BasicResponse result, string context = "");
}