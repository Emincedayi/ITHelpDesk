using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ITHelpDesk.Data;

/* This is used if database provider does't define
 * IITHelpDeskDbSchemaMigrator implementation.
 */
public class NullITHelpDeskDbSchemaMigrator : IITHelpDeskDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
