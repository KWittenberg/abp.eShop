using eShop.Blog;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace eShop.Web.Pages.Blog;

public class IndexModel : PageModel
{
    public List<BlogDto> Blogs { get; set; }

    private readonly IBlogAppService _blogAppService;

    public IndexModel(IBlogAppService blogAppService)
    {
        _blogAppService = blogAppService;
    }


    public async Task OnGetAsync()
    {
        Blogs = await _blogAppService.GetBlogs();
    }
}