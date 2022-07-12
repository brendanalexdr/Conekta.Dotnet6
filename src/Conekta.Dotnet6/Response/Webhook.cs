using Conekta.Dotnet6.Base;
using Conekta.Dotnet6.Models;

namespace Conekta.Dotnet6.Response;

public class Webhook : IConektaObject
{
    public string id { get; set; }
    public string type { get; set; }
    public string @object { get; set; }
    public bool livemode { get; set; }
    public int created_at { get; set; }
    public int updated_at { get; set; }
    public string webhook_status { get; set; }
    public List<WebhookLog> webhook_logs { get; set; }
    public WebhookData data { get; set; }

    public Models.Webhook GetWebhook()
    {
        var webhookLogs = new List<Models.WebhookLog>();
        if (webhook_logs != null)
        {
            webhookLogs = this.webhook_logs;
        }

        return new Models.Webhook
        {
            id = id,
            created_at = created_at,
            status = webhook_status,
            type = type,
            webhook_logs = webhookLogs,
            @object = data.@object,
            previous_attributes = data.previous_attributes

        };

    }
}
