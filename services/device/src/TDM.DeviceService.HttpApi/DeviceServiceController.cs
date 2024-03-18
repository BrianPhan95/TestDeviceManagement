using TDM.DeviceService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TDM.DeviceService;

public abstract class DeviceServiceController : AbpControllerBase
{
    protected DeviceServiceController()
    {
        LocalizationResource = typeof(DeviceServiceResource);
    }
}
