using TDM.AdministrationService.EntityFrameworkCore;
using TDM.Shared.Hosting;
using Volo.Abp.Modularity;
namespace TDM.Microservice.Shared
{
    [DependsOn(
     typeof(TDMHostingModule),
     typeof(AdministrationServiceEntityFrameworkCoreModule)
 )]
    public class TDMMicroserviceModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
