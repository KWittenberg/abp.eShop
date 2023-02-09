using System.ComponentModel.DataAnnotations;

namespace eShop.Categories;

public class CreateCategoryDto
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }
}