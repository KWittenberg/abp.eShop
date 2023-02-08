using System.Threading.Tasks;
using eShop.Localization;
using eShop.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace eShop.Web.Menus;

public class eShopMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<eShopResource>();

        context.Menu.Items.Insert(0, new ApplicationMenuItem( eShopMenus.Home, l["Menu:Home"], "~/", icon: "fas fa-home", order: 0));
        context.Menu.Items.Insert(0, new ApplicationMenuItem( eShopMenus.Home, l["Menu:Todo"], url: "/Todo", icon: "fa fa-th-list", order: 1));
        //context.Menu.Items.Insert(0, new ApplicationMenuItem( eShopMenus.Home, l["Menu:Products"], url: "/Products", icon: "fas fa-shopping-cart", order: 2));

        context.Menu.AddItem(new ApplicationMenuItem("eShop", l["Menu:eShop"], icon: "fas fa-shopping-cart")
            .AddItem(new ApplicationMenuItem("eShop.Categories", l["Menu:Categories"], url: "/Categories"))
            .AddItem(new ApplicationMenuItem("eShop.Products", l["Menu:Products"], url: "/Products")));

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
