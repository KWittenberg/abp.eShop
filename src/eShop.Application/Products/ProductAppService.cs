using eShop.Categories;
using eShop.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace eShop.Products;

public class ProductAppService : eShopAppService, IProductAppService
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public ProductAppService(IRepository<Product, Guid> productRepository, IRepository<Category, Guid> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }


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
}