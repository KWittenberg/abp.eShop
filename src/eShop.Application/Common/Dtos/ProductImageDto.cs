namespace eShop.Common.Dtos;

public class ProductImageDto : AuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }

    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public DateTime ReleaseDate { get; set; }
}