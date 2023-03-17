namespace eShop.EntityFrameworkCore.Configurations;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses");
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired();
        builder.HasQueryFilter(x => !x.User.IsDeleted);
        builder.OwnsOne(x => x.Address, o =>
        {
            o.Property(p => p.AddressType).HasConversion<int>();
            o.Property(p => p.Country).IsRequired().HasMaxLength(AddressConsts.MaxCountryLength);
            o.Property(p => p.CountryCode).IsRequired().HasMaxLength(AddressConsts.MaxCountryCodeLength);
            o.Property(p => p.PostalCode).IsRequired().HasMaxLength(AddressConsts.MaxPostalCodeLength);
            o.Property(p => p.City).IsRequired().HasMaxLength(AddressConsts.MaxCityLength);
            o.Property(p => p.Street).IsRequired().HasMaxLength(AddressConsts.MaxStreetLength);
            o.Property(p => p.Number).IsRequired().HasMaxLength(AddressConsts.MaxNumberLength);
        });
    }
}