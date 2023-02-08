using Volo.Abp.Modularity;

namespace eShop;

[DependsOn(
    typeof(eShopApplicationModule),
    typeof(eShopDomainTestModule)
    )]
public class eShopApplicationTestModule : AbpModule
{

}
