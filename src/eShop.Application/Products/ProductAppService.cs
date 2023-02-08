using eShop.Categories;
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
    private readonly IRepository<Category,Guid> _categoryRepository;

    public ProductAppService(IRepository<Product, Guid> productRepository, IRepository<Category, Guid> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    // Get List
    public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        /* TODO: Implementation */
        
        var queryable = await _productRepository.WithDetailsAsync(x => x.Category);
        queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).OrderBy(input.Sorting ?? nameof(Product.Name));

        var products = await AsyncExecuter.ToListAsync(queryable);
        var count = await _productRepository.GetCountAsync();
        return new PagedResultDto<ProductDto>(count, ObjectMapper.Map<List<Product>, List<ProductDto>>(products));
    }

    // Create Update
    public async Task CreateAsync(CreateUpdateProductDto input)
    {
        await _productRepository.InsertAsync(ObjectMapper.Map<CreateUpdateProductDto, Product>(input));
    }
    
    // Category Lookup
    public async Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetListAsync();
        return new ListResultDto<CategoryLookupDto>(ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories));
    }
}