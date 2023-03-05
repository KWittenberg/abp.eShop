namespace eShop;

/* Inherit your application services from this class. */
public abstract class eShopAppService : ApplicationService
{
    protected eShopAppService()
    {
        LocalizationResource = typeof(eShopResource);
    }
}