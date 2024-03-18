using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TDM.DeviceService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(DeviceServiceDomainSharedModule)
)]
public class DeviceServiceDomainModule : AbpModule
{

}
