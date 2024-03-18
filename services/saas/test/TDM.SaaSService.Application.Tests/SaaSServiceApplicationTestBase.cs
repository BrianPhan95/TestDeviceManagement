using Volo.Abp.Modularity;

namespace TDM.SaaSService;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class SaaSServiceApplicationTestBase<TStartupModule> : SaaSServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
