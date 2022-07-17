using Conekta.Dotnet6.Base;
using ConektaDotnet6.Models;
using ConektaDotnet6.Values;

namespace ConektaDotnet6.Response;

public class Webhook : IConektaObject 
{

    public string id { get; set; }

    public string @object { get; set; }
    public bool livemode { get; set; }
    public ConektaDatetime updated_at { get; set; }
    public string webhook_status { get; set; }
    public List<WebhookLog> webhook_logs { get; set; }
    public WebhookData data { get; set; }
    public ConektaDatetime created_at { get; set; }

    public ConektaEventType type { get; set; }

    string IConektaObject.type => throw new NotImplementedException();

    public Models.Event GetEvent()
    {
        var _webhookLogs = new List<Models.WebhookLog>();
        if (webhook_logs != null)
        {
            _webhookLogs = this.webhook_logs;
        }

        return new Models.Event
        {
            Id = this.id,
            CreatedAt = this.created_at,
            Status = this.webhook_status,
            Type = this.type,
            WebhookLogs = _webhookLogs,
            Object = data.@object,
            PreviousAttributes = data.previous_attributes

        };

    }
}
