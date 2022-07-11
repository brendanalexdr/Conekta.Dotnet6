namespace Conekta.Dotnet6.Models;

public class WebhookLog
{ 
    public string id { get; set; }

    public string url { get; set; }

    public int failed_attemps { get; set; }

    public int last_http_response_status { get; set; }

    public string @object { get; set; }

    public int last_attempted_at { get; set; }
}
