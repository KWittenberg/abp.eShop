using eShop.AppServices.Products.Dtos;

namespace eShop.AppServices.Products;

public interface IProductAppService : IApplicationService
{
    // Product //////////////////////////////////////////////////////////
    // Get List
    Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    // Get Categories
    Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync();

    // Get by Id
    Task<ProductDto> GetAsync(Guid id);


    // Create
    Task<ProductDto> CreateAsync(AddProductDto model);
    // Update
    Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto model);
    // Delete
    Task DeleteAsync(Guid id);


    // Product Image //////////////////////////////////////////////////////////
    Task<List<ProductImageDto>> GetProductImagesByProductId(Guid productId);
    Task<ProductImageDto> CreateProductImage(AddProductImageDto model);
    Task<ProductImageDto> UpdateProductImage(Guid productImageId, UpdateProductImageDto model);
    Task DeleteProductImage(Guid productImageId);
}