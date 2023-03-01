namespace eShop.AppServices.Blogs.Dtos;

public class AddBlogDto
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public bool Publish { get; set; }
}