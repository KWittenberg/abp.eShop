namespace eShop.AppServices.Categories;

public interface ICategoryAppService : IApplicationService
{
    // Get List
    Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input);

    // Get Category by Id
    Task<CategoryDto> GetAsync(Guid id);


    // Create
    Task<CategoryDto> CreateAsync(AddCategoryDto model);
    // Update
    Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto model);
    // Delete
    Task DeleteAsync(Guid id);
}