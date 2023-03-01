using eShop.Entities.Categories;

namespace eShop.Entities.Products;

public class Product : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public float Price { get; set; }
    public bool IsFreeCargo { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ProductStockState StockState { get; set; }

    // Add Category
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }

    // Add ProductImages
    public ICollection<ProductImage> ProductImages { get; set; }
}