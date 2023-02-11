using AutoMapper;
using eShop.Categories;
using eShop.Products;
using eShop.Todo;

namespace eShop;

public class eShopApplicationAutoMapperProfile : Profile
{
    public eShopApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // Todo
        CreateMap<TodoItem, TodoItemDto>();
        CreateMap<AddTodoItemDto, TodoItem>();
        CreateMap<UpdateTodoItemDto, TodoItem>();
        
        // Category
        CreateMap<Category, CategoryDto>();
        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();






        CreateMap<Category, CategoryLookupDto>();
        //CreateMap<CreateUpdateCategoryDto, Category>();
        //CreateMap<CreateCategoryDto, Category>();
        //CreateMap<UpdateCategoryDto, Category>();
        // Product
        CreateMap<Product, ProductDto>();
        //CreateMap<CreateUpdateProductDto, Product>();
    }
}