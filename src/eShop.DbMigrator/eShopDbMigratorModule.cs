using eShop.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace eShop.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(eShopEntityFrameworkCoreModule),
    typeof(eShopApplicationContractsModule)
    )]
public class eShopDbMigratorModule : AbpModule
{

}
