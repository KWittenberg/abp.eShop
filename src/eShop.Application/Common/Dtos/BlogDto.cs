namespace eShop.Common.Dtos;

public class BlogDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public bool Publish { get; set; }



    // Add User
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    //public UserDto User { get; set; }
    //public Guid UserId { get; set; }

    public DateTime CreationTime { get; set; }
    public DateTime LastModificationTime { get; set; }
}