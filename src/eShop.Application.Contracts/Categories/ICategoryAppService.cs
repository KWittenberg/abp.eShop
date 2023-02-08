using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eShop.Categories;

public interface ICategoryAppService : IApplicationService
{
    // Get List
    Task<ListResultDto<CategoryDto>> GetListAsync();
    // Create Update
    Task CreateAsync(CreateUpdateCategoryDto input);
    
    
    
    //Task<CategoryDto> CreateAsync(string text);


    //Task<PagedResultDto<CategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input);


    //Task<List<CategoryDto>> GetCategoriesAsync();

    //Task DeleteAsync(Guid id);
}