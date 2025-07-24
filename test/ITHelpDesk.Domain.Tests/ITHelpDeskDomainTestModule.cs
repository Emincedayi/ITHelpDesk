using Volo.Abp.Modularity;

namespace ITHelpDesk;

[DependsOn(
    typeof(ITHelpDeskDomainModule),
    typeof(ITHelpDeskTestBaseModule)
)]
public class ITHelpDeskDomainTestModule : AbpModule
{

}
