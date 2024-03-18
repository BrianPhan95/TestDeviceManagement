using Volo.Abp.Modularity;

namespace TDM.DeviceService;

[DependsOn(
    typeof(DeviceServiceDomainModule),
    typeof(DeviceServiceTestBaseModule)
)]
public class DeviceServiceDomainTestModule : AbpModule
{

}
