namespace eShop.Data;

public interface IeShopDbSchemaMigrator
{
    Task MigrateAsync();
}
