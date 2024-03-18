using Volo.Abp.Modularity;

namespace TDM.DeviceService;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class DeviceServiceDomainTestBase<TStartupModule> : DeviceServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
