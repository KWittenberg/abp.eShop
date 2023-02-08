using eShop.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace eShop;

[DependsOn(
    typeof(eShopEntityFrameworkCoreTestModule)
    )]
public class eShopDomainTestModule : AbpModule
{

}
