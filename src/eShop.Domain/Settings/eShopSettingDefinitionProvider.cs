using Volo.Abp.Settings;

namespace eShop.Settings;

public class eShopSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(eShopSettings.MySetting1));
    }
}
