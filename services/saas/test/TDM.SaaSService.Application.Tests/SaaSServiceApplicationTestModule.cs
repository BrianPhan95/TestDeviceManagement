using Volo.Abp.Modularity;

namespace TDM.SaaSService;

[DependsOn(
    typeof(SaaSServiceApplicationModule),
    typeof(SaaSServiceDomainTestModule)
    )]
public class SaaSServiceApplicationTestModule : AbpModule
{

}
