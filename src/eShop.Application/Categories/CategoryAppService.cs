using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace eShop.Categories;

public class CategoryAppService : eShopAppService, ICategoryAppService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryManager _categoryManager;

    public CategoryAppService(ICategoryRepository categoryRepository, CategoryManager categoryManager)
    {
        _categoryRepository = categoryRepository;
        _categoryManager = categoryManager;
    }

    /// <summary>
    /// OLD Get List
    /// </summary>
    /// <returns></returns>
    //public async Task<ListResultDto<CategoryDto>> GetListAsync()
    //public async Task<List<CategoryDto>> GetListAsync()
    //{
    //    var categories = await _categoryRepository.GetListAsync();
    //    return new List<CategoryDto>(ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories));
    //}





    public async Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Category.Name);
        }

        var categories = await _categoryRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);
        var totalCount = input.Filter == null ? await _categoryRepository.CountAsync() : await _categoryRepository.CountAsync(category => category.Name.Contains(input.Filter));
        return new PagedResultDto<CategoryDto>(totalCount, ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories));
    }



    /// <summary>
    /// Get Category by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<CategoryDto> GetAsync(Guid id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return ObjectMapper.Map<Category, CategoryDto>(category);
    }


    /// <summary>
    /// Create
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
    {
        var category = await _categoryManager.CreateAsync(input.Name);
        await _categoryRepository.InsertAsync(category);
        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task UpdateAsync(Guid id, UpdateCategoryDto input)
    {
        var category = await _categoryRepository.GetAsync(id);

        if (category.Name != input.Name)
        {
            await _categoryManager.ChangeNameAsync(category, input.Name);
        }

        category.Name = input.Name;

        await _categoryRepository.UpdateAsync(category);
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }



    /// <summary>
    /// OLD Create
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    //public async Task CreateAsync(CreateUpdateCategoryDto input)
    //{
    //    await _categoryRepository.InsertAsync(ObjectMapper.Map<CreateUpdateCategoryDto, Category>(input));
    //}












    //public async Task<List<CategoryDto>> GetCategoriesAsync()
    //{
    //    var items = await _categoryRepository.GetListAsync();
    //    return items.Select(item => new CategoryDto { Id = item.Id, Name = item.Name }).ToList();
    //}
}