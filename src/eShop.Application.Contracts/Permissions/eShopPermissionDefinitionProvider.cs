using eShop.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace eShop.Permissions;

public class eShopPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(eShopPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(eShopPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<eShopResource>(name);
    }
}
