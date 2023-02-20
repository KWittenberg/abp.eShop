using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace eShop.Blog;

public class Blog : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public bool Publish { get; set; }


    // Add User
    //[ForeignKey("UserId")]
    public IdentityUser User { get; set; }
    public Guid UserId { get; set; }
}