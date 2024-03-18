using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace TDM.SaaSService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SaaSServiceDomainSharedModule)
)]
[DependsOn(typeof(AbpTenantManagementDomainModule))]
    public class SaaSServiceDomainModule : AbpModule
{

}
