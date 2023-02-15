using eShop.Products;
using eShop.Todo;
using System.Collections.Generic;

namespace eShop.Web.Pages.Products;

public class ProductImage : eShopPageModel
{
    public List<ProductImageDto> ProductImages { get; set; }
    public Guid ProductId { get; set; }

    private readonly IProductAppService _productAppService;
    
    public ProductImage(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    public async Task OnGetAsync(Guid Id)
    {
        ProductImages = await _productAppService.GetProductImagesByProductId(Id);
    }
}