using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eShop.Interfaces.Repositories
{
    public interface IBlogRepository : IRepository<Blog.Blog, Guid>
    {
        Task<List<Blog.Blog>> GetBlogs();
        Task<Blog.Blog> GetBlog(Guid blogId);
    }
}
