namespace eShop.Entities.Products;

public class ProductImage : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    // Add Product
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
}