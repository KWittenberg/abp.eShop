namespace eShop.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AddressType : byte
{
    Home,
    Office,
    Delivery
}