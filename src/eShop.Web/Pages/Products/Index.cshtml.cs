namespace eShop.Web.Pages.Products;

public class IndexModel : PageModel
{
    public List<ProductDto> Products { get; set; }

    private readonly IProductAppService _productAppService;

    public IndexModel(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }


    public async Task OnGetAsync()
    {
        GetProductListDto model = new GetProductListDto();
        // Populate the properties of the model object as needed
        var result = await _productAppService.GetListAsync(model);
        Products = (List<ProductDto>)result.Items;
    }
}