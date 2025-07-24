using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ITHelpDesk.Data;
using Volo.Abp.DependencyInjection;

namespace ITHelpDesk.EntityFrameworkCore;

public class EntityFrameworkCoreITHelpDeskDbSchemaMigrator
    : IITHelpDeskDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreITHelpDeskDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ITHelpDeskDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ITHelpDeskDbContext>()
            .Database
            .MigrateAsync();
    }
}
