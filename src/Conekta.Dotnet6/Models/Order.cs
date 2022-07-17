using ConektaDotnet6.Values;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Models;

public class Order
{

    [JsonPropertyName("order_id")]
    public string OrderId { get; set; }

    [JsonPropertyName("amount")]
    public ConektaAmount Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("amount_refunded ")]
    public ConektaAmount AmountRefunded { get; set; }

    [JsonPropertyName("payment_status")]
    public PaymentStatus PaymentStatus { get; set; }

    [JsonPropertyName("line_items")]
    public List<LineItem> LineItems { get; set; }

    [JsonPropertyName("customer_info")]
    public Customer CustomerInfo { get; set; }

    [JsonPropertyName("charges")]
    public List<Charge> Charges { get; set; }

    [JsonPropertyName("returns")]
    public List<Return> Returns { get; set; }

    [JsonPropertyName("shipping_lines")]
    public List<ShippingLine> ShippingLines { get; set; }

    [JsonPropertyName("customer_id")]
    public string CustomerId { get; set; }

    [JsonPropertyName("metadata ")]
    public JsonDocument Metadata { get; set; }

    [JsonPropertyName("pre_authorize")]
    public bool PreAuthorize { get; set; }

    [JsonPropertyName("created_at")]
    public ConektaDatetime created_at { get; set; }

    [JsonPropertyName("updated_at")]
    public ConektaDatetime UpdtedAt { get; set; }

}
