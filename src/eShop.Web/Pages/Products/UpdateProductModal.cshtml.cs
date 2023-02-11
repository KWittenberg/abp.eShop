using eShop.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace eShop.Web.Pages.Products
{
    public class UpdateProductModalModel : eShopPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public UpdateProductViewModel Product { get; set; }
        public SelectListItem[] Categories { get; set; }
        private readonly IProductAppService _productAppService;

        public UpdateProductModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            var productDto = await _productAppService.GetAsync(Id);
            Product = ObjectMapper.Map<ProductDto, UpdateProductViewModel>(productDto);
            var categoryLookup = await _productAppService.GetCategoriesAsync();
            Categories = categoryLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.UpdateAsync(Id, ObjectMapper.Map<UpdateProductViewModel, UpdateProductDto>(Product));
            return NoContent();
        }


    }
}