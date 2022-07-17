using ConektaDotnet6.Values;

namespace ConektaDotnet6.Models;

public class PaymentLink
{
    public string id { get; set; }
    public string name { get; set; }

    public bool recurrent { get; set; }

    public ConektaDatetime expires_at { get; set; }

    public string[] allowed_payment_methods { get; set; }

    public bool needs_shipping_contact { get; set; }

    public int[] monthly_installments_options { get; set; }

    public OrderTemplate order_template { get; set; }

    public string success_url { get; set; }

    public string failure_url   { get; set; }
    public string status { get; set; }

    public Dictionary<string, string> metadata = new Dictionary<string, string>();

    public bool can_not_expire { get; set; }

    public string slug { get; set; }

    public string url { get; set; }


}
