using AutoMapper;
using eShop.Categories;
using eShop.Products;
using eShop.Todo;

namespace eShop;

public class eShopApplicationAutoMapperProfile : Profile
{
    public eShopApplicationAutoMapperProfile()
    {
        // Todo
        CreateMap<TodoList, TodoListDto>();
        CreateMap<AddTodoListDto, TodoList>();
        CreateMap<UpdateTodoListDto, TodoItem>();

        CreateMap<TodoItem, TodoItemDto>();
        CreateMap<AddTodoItemDto, TodoItem>();
        CreateMap<UpdateTodoItemDto, TodoItem>();
        

        // Category
        CreateMap<Category, CategoryDto>();
        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        
        
        // Product
        CreateMap<Product, ProductDto>();
        CreateMap<AddProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Category, CategoryLookupDto>();

        CreateMap<ProductImage, ProductImageDto>();
        CreateMap<AddProductImageDto, ProductImage>();
    }
}