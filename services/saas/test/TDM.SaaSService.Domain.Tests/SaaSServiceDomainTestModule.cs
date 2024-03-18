using Volo.Abp.Modularity;

namespace TDM.SaaSService;

[DependsOn(
    typeof(SaaSServiceDomainModule),
    typeof(SaaSServiceTestBaseModule)
)]
public class SaaSServiceDomainTestModule : AbpModule
{

}
