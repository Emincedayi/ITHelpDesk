using ITHelpDesk.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ITHelpDesk.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ITHelpDeskEntityFrameworkCoreModule),
    typeof(ITHelpDeskApplicationContractsModule)
)]
public class ITHelpDeskDbMigratorModule : AbpModule
{
}
