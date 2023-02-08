using System.ComponentModel.DataAnnotations;

namespace eShop.Categories;

public class CreateUpdateCategoryDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }
}