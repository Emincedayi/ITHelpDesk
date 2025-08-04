using Hangfire;
using Hangfire.PostgreSql;
using ITHelpDesk.EntityFrameworkCore;
using ITHelpDesk.Tickets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Hangfire;
using Volo.Abp.Modularity;

namespace ITHelpDesk.Web
{
    [DependsOn(
        typeof(ITHelpDeskApplicationModule),
        typeof(ITHelpDeskEntityFrameworkCoreModule),
        typeof(AbpHangfireModule)
    )]
    public class ITHelpDeskWebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            // Hangfire yapılandırması (PostgreSQL)
            context.Services.AddHangfire(config =>
            {
                config.UsePostgreSqlStorage(configuration.GetConnectionString("Default"));
            });

            // Background job'ların çalışmasını etkinleştir
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = true;
            });
        }

      /*  public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            // Hangfire Dashboard'ı etkinleştir
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = (System.Collections.Generic.IEnumerable<Hangfire.Dashboard.IDashboardAuthorizationFilter>)(new[] { new AbpHangfireAuthorizationFilter() })
            });

            // Periyodik görevi planla (her saat)
            RecurringJob.AddOrUpdate<StaleTicketNotificationJob>(
                "stale-ticket-notification",
                job => job.ExecuteAsync(),
                Cron.Hourly
            );

            app.InitializeApplication();
        }*/
    }
}