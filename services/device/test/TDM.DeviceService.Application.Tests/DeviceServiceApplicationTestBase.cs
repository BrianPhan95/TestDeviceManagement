using Volo.Abp.Modularity;

namespace TDM.DeviceService;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class DeviceServiceApplicationTestBase<TStartupModule> : DeviceServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
