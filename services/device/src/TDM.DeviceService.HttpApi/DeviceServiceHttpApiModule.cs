using Localization.Resources.AbpUi;
using TDM.DeviceService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TDM.DeviceService;

[DependsOn(
    typeof(DeviceServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class DeviceServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(DeviceServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<DeviceServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
