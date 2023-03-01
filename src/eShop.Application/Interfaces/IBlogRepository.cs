using eShop.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eShop.Interfaces;

public interface IBlogRepository : IRepository<Blog, Guid>
{
    Task<List<Blog>> GetBlogs();
    Task<Blog> GetBlog(Guid blogId);
}