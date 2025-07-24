using ITHelpDesk.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ITHelpDesk.Blazor;

public abstract class ITHelpDeskComponentBase : AbpComponentBase
{
    protected ITHelpDeskComponentBase()
    {
        LocalizationResource = typeof(ITHelpDeskResource);
    }
}
