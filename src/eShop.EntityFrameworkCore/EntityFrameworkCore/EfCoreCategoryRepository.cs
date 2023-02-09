using eShop.Categories;
using eShop.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace eShop;

public class EfCoreCategoryRepository : EfCoreRepository<eShopDbContext, Category, Guid>, ICategoryRepository
{
    public EfCoreCategoryRepository(IDbContextProvider<eShopDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Category> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(category => category.Name == name);
    }

    public async Task<List<Category>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), category => category.Name.Contains(filter)).OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();
    }
}