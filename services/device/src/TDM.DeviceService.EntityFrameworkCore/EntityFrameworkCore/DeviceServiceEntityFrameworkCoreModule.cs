using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TDM.DeviceService.EntityFrameworkCore;

[DependsOn(
    typeof(DeviceServiceDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class DeviceServiceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DeviceServiceDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */

            options.AddDefaultRepositories(true);
        });
    }
}
