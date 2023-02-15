using System;
using Volo.Abp.Application.Dtos;

namespace eShop.Products;

public class AddProductImageDto
{
    public Guid ProductId { get; set; }

    public string Name { get; set; }
    public string ImageUrl { get; set; }
}