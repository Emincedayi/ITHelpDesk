using ITHelpDesk.Categories;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace ITHelpDesk;

[DependsOn(
    typeof(ITHelpDeskDomainModule),
    typeof(ITHelpDeskApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class ITHelpDeskApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<CategoryMappingProfile>();
        });
      /*  Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<ITHelpDeskApplicationAutoMapperProfile>(validate: true);
        });*/

        Configure<AbpExceptionHandlingOptions>(options =>
        {
            options.SendExceptionsDetailsToClients = true;
        });

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ITHelpDeskApplicationModule>();
        });


    }
}
