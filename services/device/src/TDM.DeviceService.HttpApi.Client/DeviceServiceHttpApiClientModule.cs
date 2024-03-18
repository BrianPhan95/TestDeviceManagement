using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TDM.DeviceService;

[DependsOn(
    typeof(DeviceServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class DeviceServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(DeviceServiceApplicationContractsModule).Assembly,
            DeviceServiceRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<DeviceServiceHttpApiClientModule>();
        });

    }
}
