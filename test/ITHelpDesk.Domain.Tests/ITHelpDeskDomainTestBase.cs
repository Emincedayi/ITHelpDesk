using Volo.Abp.Modularity;

namespace ITHelpDesk;

/* Inherit from this class for your domain layer tests. */
public abstract class ITHelpDeskDomainTestBase<TStartupModule> : ITHelpDeskTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
