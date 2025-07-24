using ITHelpDesk.Localization;
using Volo.Abp.Application.Services;

namespace ITHelpDesk;

/* Inherit your application services from this class.
 */
public abstract class ITHelpDeskAppService : ApplicationService
{
    protected ITHelpDeskAppService()
    {
        LocalizationResource = typeof(ITHelpDeskResource);
    }
}
