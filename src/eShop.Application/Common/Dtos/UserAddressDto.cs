namespace eShop.Common.Dtos;

public class UserAddressDto
{
    public Guid UserId { get; set; }

    public Guid Id { get; set; }
    public Address Address { get; set; }
}