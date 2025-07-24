using Microsoft.Extensions.Localization;
using ITHelpDesk.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ITHelpDesk.Blazor;

[Dependency(ReplaceServices = true)]
public class ITHelpDeskBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ITHelpDeskResource> _localizer;

    public ITHelpDeskBrandingProvider(IStringLocalizer<ITHelpDeskResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
