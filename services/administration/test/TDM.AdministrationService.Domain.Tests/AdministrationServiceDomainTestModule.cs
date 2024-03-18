using Volo.Abp.Modularity;

namespace TDM.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceDomainModule),
    typeof(AdministrationServiceTestBaseModule)
)]
public class AdministrationServiceDomainTestModule : AbpModule
{

}
