using Conekta.Dotnet6.Values;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Models;

public class Event
{

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("created_at")]

    public UnixTimestamp CreatedAt { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("type")]
    public ConektaEventType Type { get; set; }

    [JsonPropertyName("webhook_logs")]
    public List<WebhookLog> WebhookLogs { get; set; }

    [JsonPropertyName("object")]
    public JsonDocument Object{ get; set; }

    [JsonPropertyName("previous_attributes")]
    public JsonDocument PreviousAttributes { get; set; }

}
