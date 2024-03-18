using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.AdministrationService;
using TDM.AdministrationService.EntityFrameworkCore;
using TDM.DeviceService;
using TDM.DeviceService.EntityFrameworkCore;
using TDM.IdentityService;
using TDM.IdentityService.EntityFrameworkCore;
using TDM.SaaSService;
using TDM.SaaSService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace TDM.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AdministrationServiceEntityFrameworkCoreModule),
        typeof(AdministrationServiceApplicationContractsModule),
        typeof(IdentityServiceEntityFrameworkCoreModule),
        typeof(IdentityServiceApplicationContractsModule),
        typeof(SaaSServiceEntityFrameworkCoreModule),
        typeof(SaaSServiceApplicationContractsModule),
        typeof(DeviceServiceEntityFrameworkCoreModule),
        typeof(DeviceServiceApplicationContractsModule)
    )]
    public class TDMDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
