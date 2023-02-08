using System.Threading.Tasks;

namespace eShop.Data;

public interface IeShopDbSchemaMigrator
{
    Task MigrateAsync();
}
