namespace Conekta.Dotnet6.Models
{

    public class Charge
    {
        public string id { get; set; }
        public bool livemode { get; set; }
        public int created_at { get; set; }
        public string currency { get; set; }
        public int amount { get; set; }
        public string parent_id { get; set; }
        public PaymentMethod payment_method { get; set; }
        public string @object { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int paid_at { get; set; }
        public int fee { get; set; }
        public string customer_id { get; set; }
        public string order_id { get; set; }
        public string reference_id { get; set; }

    }
}
