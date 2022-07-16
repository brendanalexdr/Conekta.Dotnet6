using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Models;

public class PaymentSource
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("exp_month")]
    public string ExpMonth { get; set; }

    [JsonPropertyName("exp_year")]
    public string ExpYear { get; set; }

    [JsonPropertyName("cvc")]
    public string Cvc { get; set; }

    [JsonPropertyName("address")]

    public Address Address { get; set; }

    [JsonPropertyName("parent_id")]

    public string ParentId { get; set; }
}
