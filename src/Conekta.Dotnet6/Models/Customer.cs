namespace Conekta.Dotnet6.Models;

public class Customer
{
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public bool corporate { get; set; }

    public PaymentSource[] payment_sources { get; set; }
    // public FiscalEntity[] fiscal_entities { get; set; }
    // public ShippingContact[] shipping_contacts { get; set; }
    // public Subscription subscription { get; set; }
    public int account_age { get; set; }
    public int paid_transactions { get; set; }
    public int first_paid_at { get; set; }
    public string customer_id { get; set; }
    public bool deleted { get; set; } = false;
}
