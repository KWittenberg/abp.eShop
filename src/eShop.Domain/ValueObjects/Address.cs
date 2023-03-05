namespace eShop.ValueObjects;

public class Address : ValueObject
{
    public AddressType AddressType { get; init; }
    public string Country { get; init; }
    public string CountryCode { get; init; }
    public string PostalCode { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string Number { get; init; }

    private Address()
    {
    }

    public Address(AddressType addressType, string country, string countryCode, string postalCode, string city, string street, string number)
    {
        AddressType = addressType;
        Country = country;
        CountryCode = countryCode;
        PostalCode = postalCode;
        City = city;
        Street = street;
        Number = number;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return AddressType;
        yield return Country;
        yield return CountryCode;
        yield return PostalCode;
        yield return City;
        yield return Street;
        yield return Number;
    }
}