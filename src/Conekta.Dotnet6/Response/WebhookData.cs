using System.Text.Json;

namespace ConektaDotnet6.Response;

public class WebhookData
{
    public JsonDocument @object { get; set; }
    public JsonDocument previous_attributes { get; set; }
}
