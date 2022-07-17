using System.Text.Json.Serialization;

namespace ConektaDotnet6.Models;

public class Webhook
{

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("subscribed_events")]
    public List<string> SubscribedEvents { get; set; }

    [JsonPropertyName("synchronous")]
    public bool Synchronous { get; set; }


    [JsonPropertyName("production_enabled")]
    public bool ProductionEnabled { get; set; }

    [JsonPropertyName("development_enabled")]
    public bool DevelopmentEnabled { get; set; }

}
