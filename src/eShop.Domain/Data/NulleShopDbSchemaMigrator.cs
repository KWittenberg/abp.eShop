using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace eShop.Data;

/* This is used if database provider does't define
 * IeShopDbSchemaMigrator implementation.
 */
public class NulleShopDbSchemaMigrator : IeShopDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
