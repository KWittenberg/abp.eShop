using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eShop.Products;

public interface IProductAppService : IApplicationService
{
    // Get List
    Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    // Get Categories
    Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync();
    
    // Create
    Task CreateAsync(CreateUpdateProductDto input);

    // Delete
    Task DeleteAsync(Guid id);



}