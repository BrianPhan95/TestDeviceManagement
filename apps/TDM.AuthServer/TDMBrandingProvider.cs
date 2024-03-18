using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TDM;

[Dependency(ReplaceServices = true)]
public class TDMBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TDM";
}
