namespace eShop.Web.Pages.Products
{
    public class AddProductModalModel : eShopPageModel
    {
        [BindProperty]
        public AddProductViewModel Product { get; set; }
        public SelectListItem[] Categories { get; set; }

        private readonly IProductAppService _productAppService;

        public AddProductModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            Product = new AddProductViewModel { ReleaseDate = Clock.Now, StockState = ProductStockState.PreOrder };
            var categoryLookup = await _productAppService.GetCategoriesAsync();
            Categories = categoryLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.CreateAsync(ObjectMapper.Map<AddProductViewModel, AddProductDto>(Product));
            return NoContent();
        }
    }
}