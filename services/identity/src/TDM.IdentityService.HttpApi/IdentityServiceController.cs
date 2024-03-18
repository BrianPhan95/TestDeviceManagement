using TDM.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TDM.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}
