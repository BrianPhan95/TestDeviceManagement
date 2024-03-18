using TDM.SaaSService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TDM.SaaSService;

public abstract class SaaSServiceController : AbpControllerBase
{
    protected SaaSServiceController()
    {
        LocalizationResource = typeof(SaaSServiceResource);
    }
}
