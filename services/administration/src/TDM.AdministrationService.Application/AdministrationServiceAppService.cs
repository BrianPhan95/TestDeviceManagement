using TDM.AdministrationService.Localization;
using Volo.Abp.Application.Services;

namespace TDM.AdministrationService;

public abstract class AdministrationServiceAppService : ApplicationService
{
    protected AdministrationServiceAppService()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
        ObjectMapperContext = typeof(AdministrationServiceApplicationModule);
    }
}
