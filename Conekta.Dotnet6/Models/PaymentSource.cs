namespace Conekta.Dotnet6.Models;

public class PaymentSource
{
    public string id { get; set; }
    public string type { get; set; }

    /* In case card token */
    public string token_id { get; set; }

    /* In case card object*/
    public string name { get; set; }
    public string number { get; set; }
    public string exp_month { get; set; }
    public string exp_year { get; set; }
    public string cvc { get; set; }
    public Address address { get; set; }
    public string parent_id { get; set; }
}
