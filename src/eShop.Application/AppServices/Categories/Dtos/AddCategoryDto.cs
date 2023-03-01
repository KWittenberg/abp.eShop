namespace eShop.AppServices.Categories.Dtos;

public class AddCategoryDto
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }
}