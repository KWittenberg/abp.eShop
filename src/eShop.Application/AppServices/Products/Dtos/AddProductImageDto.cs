namespace eShop.AppServices.Products.Dtos;

public class AddProductImageDto
{
    public Guid ProductId { get; set; }

    public string Name { get; set; }
    public string ImageUrl { get; set; }
}