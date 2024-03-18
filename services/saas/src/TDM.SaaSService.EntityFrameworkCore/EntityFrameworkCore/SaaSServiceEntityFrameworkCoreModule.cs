using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace TDM.SaaSService.EntityFrameworkCore;

[DependsOn(
    typeof(SaaSServiceDomainModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
)]
public class SaaSServiceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //context.Services.AddAbpDbContext<SaaSServiceDbContext>(options =>
        //{
        //        /* Add custom repositories here. Example:
        //         * options.AddRepository<Question, EfCoreQuestionRepository>();
        //         */
        //});

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        context.Services.AddAbpDbContext<SaaSServiceDbContext>(options =>
        {
            options.ReplaceDbContext<ITenantManagementDbContext>();
            options.AddDefaultRepositories(true);
        });
    }
}
