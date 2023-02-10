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
        // Populate the properties of the input object as needed
        var result = await _categoryAppService.GetListAsync(input);
        Categories = (List<CategoryDto>)result.Items;
    }
}

//public class IndexModel : PageModel
//{
//    public void OnGet()
//    {
//    }
//}

//public class IndexModel : eShopPageModel
//{
//    public List<CategoryDto> Categories { get; set; }

//    private readonly ICategoryAppService _categoryAppService;

//    public IndexModel(ICategoryAppService categoryAppService)
//    {
//        _categoryAppService = categoryAppService;
//    }

//    //public async Task OnGetAsync()
//    //{
//    //    Categories = await _categoryAppService.GetListAsync();
//    //}