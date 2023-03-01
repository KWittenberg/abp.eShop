namespace eShop.Common.Dtos;

public class GetCategoryListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}