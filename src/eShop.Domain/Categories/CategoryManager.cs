using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace eShop.Categories;

public class CategoryManager : DomainService , ITransientDependency
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="CategoryAlreadyExistsException"></exception>
    public async Task<Category> CreateAsync([NotNull] string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingCategory = await _categoryRepository.FindByNameAsync(name);
        if (existingCategory != null)
        {
            throw new CategoryAlreadyExistsException(name);
        }

        return new Category(GuidGenerator.Create(), name);
    }

    /// <summary>
    /// Change Name
    /// </summary>
    /// <param name="category"></param>
    /// <param name="newName"></param>
    /// <returns></returns>
    /// <exception cref="CategoryAlreadyExistsException"></exception>
    public async Task ChangeNameAsync([NotNull] Category category, [NotNull] string newName)
    {
        Check.NotNull(category, nameof(category));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingCategory = await _categoryRepository.FindByNameAsync(newName);
        if (existingCategory != null && existingCategory.Id != category.Id)
        {
            throw new CategoryAlreadyExistsException(newName);
        }

        category.ChangeName(newName);
    }
}