using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Inva.LawMax.Web;

[Dependency(ReplaceServices = true)]
public class LawMaxBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LawMax";
}
