using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace eShop.Blog;

public interface IBlogAppService : IApplicationService
{
    Task<List<BlogDto>> GetBlogs();
    Task<BlogDto> GetBlog(Guid blogId);
    Task<BlogDto> CreateBlog(AddBlogDto model);
    Task<BlogDto> UpdateBlog(Guid blogId, UpdateBlogDto model);
    Task DeleteBlog(Guid blogId);
}