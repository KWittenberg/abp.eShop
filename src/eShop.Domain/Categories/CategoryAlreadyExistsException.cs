using Volo.Abp;

namespace eShop.Categories;

public class CategoryAlreadyExistsException : BusinessException
{
    public CategoryAlreadyExistsException(string name) : base(eShopDomainErrorCodes.CategoryAlreadyExists)
    {
        WithData("name", name);
    }
}