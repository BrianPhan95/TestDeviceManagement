using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;

namespace TDM.AdministrationService;

[DependsOn(
     typeof(AbpDddDomainModule),
    typeof(AdministrationServiceDomainSharedModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpFeatureManagementDomainModule)
)]
    public class AdministrationServiceDomainModule : AbpModule
{

}
