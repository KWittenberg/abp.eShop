using Volo.Abp.Application.Dtos;

namespace eShop.Products;

public class GetProductListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}