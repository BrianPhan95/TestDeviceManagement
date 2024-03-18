using TDM.DeviceService.Localization;
using Volo.Abp.Application.Services;

namespace TDM.DeviceService;

public abstract class DeviceServiceAppService : ApplicationService
{
    protected DeviceServiceAppService()
    {
        LocalizationResource = typeof(DeviceServiceResource);
        ObjectMapperContext = typeof(DeviceServiceApplicationModule);
    }
}
