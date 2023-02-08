using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace eShop.Categories;

public class CategoryAppService : eShopAppService, ICategoryAppService
{
    private readonly IRepository<Category, Guid> _categoryRepository;

    public CategoryAppService(IRepository<Category, Guid> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    /// <summary>
    /// Get List
    /// </summary>
    /// <returns></returns>
    public async Task<ListResultDto<CategoryDto>> GetListAsync()
    {
        var categories = await _categoryRepository.GetListAsync();
        return new ListResultDto<CategoryDto>(ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories));
    }

    /// <summary>
    /// Create Update
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task CreateAsync(CreateUpdateCategoryDto input)
    {
        await _categoryRepository.InsertAsync(ObjectMapper.Map<CreateUpdateCategoryDto, Category>(input));
    }







    //public async Task<List<CategoryDto>> GetCategoriesAsync()
    //{
    //    var items = await _categoryRepository.GetListAsync();
    //    return items.Select(item => new CategoryDto { Id = item.Id, Name = item.Name }).ToList();
    //}


}