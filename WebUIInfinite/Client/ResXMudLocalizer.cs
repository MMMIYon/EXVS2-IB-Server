using Microsoft.Extensions.Localization;
using MudBlazor;
using WebUIInfinite.Shared.Resources;

namespace WebUIInfinite.Client
{
    internal class ResXMudLocalizer : MudLocalizer
    {
        private IStringLocalizer _localization;

        public ResXMudLocalizer(IStringLocalizer<Resource> localizer)

        {
            _localization = localizer;
        }

        public override LocalizedString this[string key] => _localization[key];
    }
}
