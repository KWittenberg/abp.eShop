namespace eShop.AppServices.Blogs;

public class BlogAppService : ApplicationService, IBlogAppService
{
    private readonly IBlogRepository _blogRepository;
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    private readonly ICurrentUser _currentUser;

    public BlogAppService(IBlogRepository blogRepository, IRepository<IdentityUser, Guid> userRepository, ICurrentUser currentUser)
    {
        _blogRepository = blogRepository;
        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    /// <summary>
    /// Get Blogs
    /// </summary>
    /// <returns></returns>
    public async Task<List<BlogDto>> GetBlogs()
    {
        var blogs = await _blogRepository.GetBlogs();
        return ObjectMapper.Map<List<Blog>, List<BlogDto>>(blogs);
    }

    /// <summary>
    /// Get Blog
    /// </summary>
    /// <param name="blogId"></param>
    /// <returns></returns>
    public async Task<BlogDto> GetBlog(Guid blogId)
    {
        var blog = await _blogRepository.GetBlog(blogId);
        return ObjectMapper.Map<Blog, BlogDto>(blog);
    }


    /// <summary>
    /// Create Blog
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public async Task<BlogDto> CreateBlog(AddBlogDto model)
    {
        var userId = _currentUser.Id;
        if (userId is null) throw new EntryPointNotFoundException("User Not Found.");

        var blog = new Blog();
        ObjectMapper.Map(model, blog);

        blog.UserId = (Guid)userId;
        blog = await _blogRepository.InsertAsync(blog);

        return ObjectMapper.Map<Blog, BlogDto>(blog);
    }

    /// <summary>
    /// Update Blog
    /// </summary>
    /// <param name="blogId"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public async Task<BlogDto> UpdateBlog(Guid blogId, UpdateBlogDto model)
    {
        var blog = await _blogRepository.GetAsync(blogId);
        if (blog is null) throw new EntryPointNotFoundException("Blog Not Found.");
        ObjectMapper.Map(model, blog);
        return ObjectMapper.Map<Blog, BlogDto>(blog);
    }

    /// <summary>
    /// Delete Blog
    /// </summary>
    /// <param name="blogId"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public async Task DeleteBlog(Guid blogId)
    {
        var blog = await _blogRepository.GetAsync(blogId);
        if (blog is null) throw new EntryPointNotFoundException("Blog Not Found.");
        await _blogRepository.DeleteAsync(blog);
    }
}