using ITHelpDesk.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.OpenIddict;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.TenantManagement;

namespace ITHelpDesk;

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(BlobStoringDatabaseDomainSharedModule)
    )]
public class ITHelpDeskDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ITHelpDeskGlobalFeatureConfigurator.Configure();
        ITHelpDeskModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ITHelpDeskDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<ITHelpDeskResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/ITHelpDesk");

            options.DefaultResourceType = typeof(ITHelpDeskResource);
            
            options.Languages.Add(new LanguageInfo("en", "en", "English")); 
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (United Kingdom)")); 
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文")); 
            options.Languages.Add(new LanguageInfo("es", "es", "Español")); 
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية")); 
            options.Languages.Add(new LanguageInfo("hi", "hi", "हिन्दी")); 
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português (Brasil)")); 
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français")); 
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский")); 
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch (Deuthschland)")); 
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe")); 
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano")); 
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština")); 
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar")); 
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română (România)")); 
            options.Languages.Add(new LanguageInfo("sv", "sv", "Svenska")); 
            options.Languages.Add(new LanguageInfo("fi", "fi", "Suomi")); 
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovenčina")); 
            options.Languages.Add(new LanguageInfo("is", "is", "Íslenska")); 
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文")); 

        });
        
        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("ITHelpDesk", typeof(ITHelpDeskResource));
        });
    }
}
