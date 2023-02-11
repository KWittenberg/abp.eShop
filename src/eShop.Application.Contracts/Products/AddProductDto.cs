using System;
using System.ComponentModel.DataAnnotations;

namespace eShop.Products;

public class AddProductDto
{
    public Guid CategoryId { get; set; }
    
    [Required]
    [StringLength(ProductConsts.MaxNameLength)]
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public float Price { get; set; }
    public bool IsFreeCargo { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ProductStockState StockState { get; set; }
}