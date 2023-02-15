﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eShop.Products;

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

}