using eShop.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace eShop.Web.Pages;

/* Inherit your PageModel classes from this class. */

public abstract class eShopPageModel : AbpPageModel
{
    protected eShopPageModel()
    {
        LocalizationResourceType = typeof(eShopResource);
    }
}