using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TDM.DeviceService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DeviceServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class DeviceServiceConsoleApiClientModule : AbpModule
{

}
