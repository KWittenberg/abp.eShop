using System.ComponentModel.DataAnnotations;

namespace eShop.Categories;

public class UpdateCategoryDto
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }
}