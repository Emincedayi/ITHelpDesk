using Volo.Abp.Modularity;

namespace ITHelpDesk;

public abstract class ITHelpDeskApplicationTestBase<TStartupModule> : ITHelpDeskTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
