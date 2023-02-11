using System.ComponentModel.DataAnnotations;

namespace eShop.Categories;

public class AddCategoryDto
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }
}