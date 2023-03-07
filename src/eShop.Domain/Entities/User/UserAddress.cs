namespace eShop.Entities.User;

public class UserAddress : AuditedEntity<Guid>
{
    // Add Address
    public Address Address { get; set; }

    // Add User
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public IdentityUser User { get; set; }
}