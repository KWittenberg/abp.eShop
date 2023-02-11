using System.Text.Json.Serialization;

namespace eShop.Products;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductStockState : byte
{
    PreOrder,
    InStock,
    NotAvailable,
    Stopped
}