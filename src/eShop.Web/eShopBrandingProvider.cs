using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace eShop.Web;

[Dependency(ReplaceServices = true)]
public class eShopBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "eShop";
}
