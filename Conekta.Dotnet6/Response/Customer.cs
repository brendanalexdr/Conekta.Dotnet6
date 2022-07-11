using Conekta.Dotnet6.Base;

namespace Conekta.Dotnet6.Response
{
    public class Customer : Models.Customer, IConektaObject
    {
        public string id { get; set; }

        public string type { get; set; }

        public string @object { get; set; }

        public bool livemode { get; set; }

        public double created_at { get; set; }

        public double updated_at { get; set; }

        public new Conekta.Dotnet6.Response.PaymentSources payment_sources { get; set; }

        public Models.Customer GetCustomer()
        {
            var paymentSources = new List<Models.PaymentSource>();
            if (this.payment_sources != null)
            {
                paymentSources = this.payment_sources.data;
            }

            return new Models.Customer
            {
                customer_id = this.id,
                name = this.name,
                email = this.email,
                phone = this.phone,
                corporate = this.corporate,
                account_age = this.account_age,
                paid_transactions = this.paid_transactions,
                first_paid_at = this.first_paid_at,
                payment_sources = paymentSources.ToArray()

            };
        }
    }
}
