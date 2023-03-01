using eShop.Entities.Blogs;
using eShop.EntityFrameworkCore;
using eShop.Interfaces;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace eShop.Infrastructure.Repositories;

public class BlogRepository : EfCoreRepository<eShopDbContext, Blog, Guid>, IBlogRepository
{
    public BlogRepository(IDbContextProvider<eShopDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    /// <summary>
    /// Get Blogs
    /// </summary>
    /// <returns></returns>
    public async Task<List<Blog>> GetBlogs()
    {
        var dbContext = await GetDbContextAsync();
        var blogs = await dbContext.Blogs.Include(x => x.User).OrderByDescending(x => x.CreationTime).ToListAsync();
        return blogs;
    }

    /// <summary>
    /// Get Blog
    /// </summary>
    /// <param name="blogId"></param>
    /// <returns></returns>
    public async Task<Blog?> GetBlog(Guid blogId)
    {
        var dbContext = await GetDbContextAsync();
        var blog = await dbContext.Blogs.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == blogId);
        return blog;
    }
}