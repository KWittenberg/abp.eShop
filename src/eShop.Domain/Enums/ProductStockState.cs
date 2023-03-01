namespace eShop.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductStockState : byte
{
    PreOrder,
    InStock,
    NotAvailable,
    Stopped
}