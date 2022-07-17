using ConektaDotnet6.Values;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Models;

public class Customer
{

    [JsonPropertyName("customer_id")]
    public string CustomerId { get; set; }

    [JsonPropertyName("created_at")]
    public ConektaDatetime created_at { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("corporate")]
    public bool Corporate { get; set; }

    [JsonPropertyName("payment_sources")]
    public PaymentSource[] PaymentSources { get; set; }

    [JsonPropertyName("default_payment_source_id")]
    public string DefaultPaymentSourceId { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; } = false;


    // public FiscalEntity[] fiscal_entities { get; set; }
    // public ShippingContact[] shipping_contacts { get; set; }
    // public Subscription subscription { get; set; }


}
