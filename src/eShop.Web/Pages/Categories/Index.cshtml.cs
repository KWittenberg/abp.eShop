using eShop.Categories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace eShop.Web.Pages.Categories;

public class IndexModel : PageModel
{
    public List<CategoryDto> Categories { get; set; }

    private readonly ICategoryAppService _categoryAppService;

    public IndexModel(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }


    public async Task OnGetAsync()
    {
        GetCategoryListDto input = new GetCategoryListDto();
        var result = await _categoryAppService.GetListAsync(input);
        Categories = (List<CategoryDto>)result.Items;
    }
}