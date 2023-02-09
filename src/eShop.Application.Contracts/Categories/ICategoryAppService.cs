using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eShop.Categories;

public interface ICategoryAppService : IApplicationService
{
    // Get List
    Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input);

    // Get Category by Id
    Task<CategoryDto> GetAsync(Guid id);


    // Create
    Task<CategoryDto> CreateAsync(CreateCategoryDto input);

    // Update
    Task UpdateAsync(Guid id, UpdateCategoryDto input);

    // Delete
    Task DeleteAsync(Guid id);
}