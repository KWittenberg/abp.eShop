using eShop.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace eShop.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class eShopController : AbpControllerBase
{
    protected eShopController()
    {
        LocalizationResource = typeof(eShopResource);
    }
}
