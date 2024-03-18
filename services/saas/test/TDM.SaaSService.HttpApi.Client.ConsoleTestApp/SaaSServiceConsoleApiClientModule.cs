using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TDM.SaaSService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SaaSServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SaaSServiceConsoleApiClientModule : AbpModule
{

}
