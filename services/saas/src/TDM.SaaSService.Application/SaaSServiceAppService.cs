using TDM.SaaSService.Localization;
using Volo.Abp.Application.Services;

namespace TDM.SaaSService;

public abstract class SaaSServiceAppService : ApplicationService
{
    protected SaaSServiceAppService()
    {
        LocalizationResource = typeof(SaaSServiceResource);
        ObjectMapperContext = typeof(SaaSServiceApplicationModule);
    }
}
