using eShop.Products;
using eShop.Web.Pages.Products;

namespace eShop.Web;

public class eShopWebAutoMapperProfile : Profile
{
    public eShopWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        // Product
        CreateMap<AddProductViewModel, AddProductDto>();
        CreateMap<UpdateProductViewModel, UpdateProductDto>();
        CreateMap<ProductDto, UpdateProductViewModel>();
    }
}