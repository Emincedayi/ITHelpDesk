using Volo.Abp.Modularity;

namespace ITHelpDesk;

[DependsOn(
    typeof(ITHelpDeskApplicationModule),
    typeof(ITHelpDeskDomainTestModule)
)]
public class ITHelpDeskApplicationTestModule : AbpModule
{

}
