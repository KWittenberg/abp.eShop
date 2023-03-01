using eShop.Entities.Categories;
using eShop.Entities.Products;

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


        // Blog
        CreateMap<Blog, BlogDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.User.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.UserName))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.User.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(x => x.User.Surname));

        CreateMap<AddBlogDto, Blog>();
        CreateMap<UpdateBlogDto, Blog>();

        // User
        CreateMap<IdentityUser, UserDto>();


    }
}