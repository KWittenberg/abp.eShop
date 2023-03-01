﻿namespace eShop.Entities.User;

public class UserAddress : AuditedAggregateRoot<Guid>
{
    // Add ProductImages
    public ICollection<Address> Address { get; set; }



    // Add User
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    
    public IdentityUser User { get; set; }
}