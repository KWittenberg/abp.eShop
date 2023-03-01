namespace eShop.Common.Dtos;

public class ProductDto : AuditedEntityDto<Guid>
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }


    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public float Price { get; set; }
    public bool IsFreeCargo { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    public ProductStockState StockState { get; set; }
}