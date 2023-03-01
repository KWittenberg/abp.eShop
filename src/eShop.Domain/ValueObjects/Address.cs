namespace eShop.ValueObjects;

public class Address : ValueObject
{
    public AddressType Type { get; private set; }

    public string Country { get; private set; }

    public string CountryCode { get; private set; }

    public string PostalCode { get; private set; }

    public string City { get; private set; }

    public string Street { get; private set; }

    public string Number { get; private set; }


    private Address()
    {
    }

    public Address(
        string country,
        string countryCode,
        string postalCode,
        string city,
        string street,
        string number)
    {
        Country = country;
        CountryCode = countryCode;
        PostalCode = postalCode;
        City = city;
        Street = street;
        Number = number;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Type;
        yield return Country;
        yield return CountryCode;
        yield return PostalCode;
        yield return City;
        yield return Street;
        yield return Number;
    }
}