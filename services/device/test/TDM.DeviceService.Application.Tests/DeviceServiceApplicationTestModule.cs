using Volo.Abp.Modularity;

namespace TDM.DeviceService;

[DependsOn(
    typeof(DeviceServiceApplicationModule),
    typeof(DeviceServiceDomainTestModule)
    )]
public class DeviceServiceApplicationTestModule : AbpModule
{

}
