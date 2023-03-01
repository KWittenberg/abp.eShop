namespace eShop.Common.Dtos;

public class GetProductListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}