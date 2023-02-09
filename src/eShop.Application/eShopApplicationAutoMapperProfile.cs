using AutoMapper;
using eShop.Categories;
using eShop.Products;

namespace eShop;

public class eShopApplicationAutoMapperProfile : Profile
{
    public eShopApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // Category
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryLookupDto>();
        //CreateMap<CreateUpdateCategoryDto, Category>();
        //CreateMap<CreateCategoryDto, Category>();
        //CreateMap<UpdateCategoryDto, Category>();
        // Product
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}