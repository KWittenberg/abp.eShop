using eShop.Categories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace eShop.Web.Pages.Categories;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}


//public class IndexModel : eShopPageModel
//{
//    public List<CategoryDto> Categories { get; set; }

//    private readonly ICategoryAppService _categoryAppService;

//    public IndexModel(ICategoryAppService categoryAppService)
//    {
//        _categoryAppService = categoryAppService;
//    }

//    public async Task OnGetAsync()
//    {
//        Categories = await _categoryAppService.GetCategoriesAsync();        
//    }
//}