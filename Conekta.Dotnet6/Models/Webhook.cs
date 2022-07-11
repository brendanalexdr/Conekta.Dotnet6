using System.Text.Json;

namespace Conekta.Dotnet6.Models;

public class Webhook
{

    public string id { get; set; }

    public double created_at { get; set; }
    public string status { get; set; }
    public string type { get; set; }
    public List<WebhookLog> webhook_logs { get; set; }
    public JsonDocument @object{ get; set; }
    public JsonDocument previous_attributes { get; set; }

}
