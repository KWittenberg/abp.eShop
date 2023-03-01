namespace eShop.Entities.Blogs;

public class Blog : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Content { get; set; }
    
    public bool Publish { get; set; }



    // Add User
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    
    public IdentityUser User { get; set; }
}