using eShop.Entities.Categories;
using eShop.Entities.Products;

namespace eShop.AppServices.Products;

public class ProductAppService : eShopAppService, IProductAppService
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<ProductImage, Guid> _productImageRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public ProductAppService(IRepository<Product, Guid> productRepository, IRepository<ProductImage, Guid> productImageRepository, IRepository<Category, Guid> categoryRepository)
    {
        _productRepository = productRepository;
        _productImageRepository = productImageRepository;
        _categoryRepository = categoryRepository;
    }

    // Product //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Get List
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _productRepository.WithDetailsAsync(x => x.Category);
        queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).OrderBy(input.Sorting ?? nameof(Product.Name));

        var products = await AsyncExecuter.ToListAsync(queryable);
        var count = await _productRepository.GetCountAsync();
        return new PagedResultDto<ProductDto>(count, ObjectMapper.Map<List<Product>, List<ProductDto>>(products));
    }

    /// <summary>
    /// Get by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);
        // if (product == null) { return null; } nije potrebno u Get
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<ProductDto> CreateAsync(AddProductDto model)
    {
        var product = new Product();
        ObjectMapper.Map(model, product);
        product = await _productRepository.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto model)
    {
        var product = await _productRepository.GetAsync(id);
        if (product == null) { throw new EntryPointNotFoundException(); } //obavezno na Update
        ObjectMapper.Map(model, product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);
        if (product == null) { throw new EntryPointNotFoundException(); }
        await _productRepository.DeleteAsync(id);
    }


    /// <summary>
    /// Category Lookup
    /// </summary>
    /// <returns></returns>
    public async Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetListAsync();
        return new ListResultDto<CategoryLookupDto>(ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories));
    }



    // Product Image ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Get Product Images
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<List<ProductImageDto>> GetProductImagesByProductId(Guid productId)
    {
        var productImage = await _productImageRepository.GetListAsync(x => x.ProductId == productId);
        return ObjectMapper.Map<List<ProductImage>, List<ProductImageDto>>(productImage);
    }

    /// <summary>
    /// Create Product Image
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public async Task<ProductImageDto> CreateProductImage(AddProductImageDto model)
    {
        var product = await _productRepository.FirstOrDefaultAsync(x => x.Id == model.ProductId);
        if (product is null) throw new EntryPointNotFoundException("Product Not Found.");

        var productImage = ObjectMapper.Map<AddProductImageDto, ProductImage>(model);
        productImage.Product = product;
        productImage = await _productImageRepository.InsertAsync(productImage);
        return ObjectMapper.Map<ProductImage, ProductImageDto>(productImage);
    }

    /// <summary>
    /// Update Product Image
    /// </summary>
    /// <param name="productImageId"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public async Task<ProductImageDto> UpdateProductImage(Guid productImageId, UpdateProductImageDto model)
    {
        var productImage = await _productImageRepository.GetAsync(productImageId);
        if (productImage is null) throw new EntryPointNotFoundException("Product Image Not Found.");
        ObjectMapper.Map(model, productImage);
        return ObjectMapper.Map<ProductImage, ProductImageDto>(productImage);
    }

    /// <summary>
    /// Delete Product Image
    /// </summary>
    /// <param name="productImageId"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public async Task DeleteProductImage(Guid productImageId)
    {
        var productImage = await _productImageRepository.GetAsync(productImageId);
        if (productImage is null) throw new EntryPointNotFoundException("Product Image Not Found.");
        await _productImageRepository.DeleteAsync(productImage);
    }
}