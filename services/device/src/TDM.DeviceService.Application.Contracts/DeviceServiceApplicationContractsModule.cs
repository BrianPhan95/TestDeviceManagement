using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TDM.DeviceService;

[DependsOn(
    typeof(DeviceServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class DeviceServiceApplicationContractsModule : AbpModule
{

}
