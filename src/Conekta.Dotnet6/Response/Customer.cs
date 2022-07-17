using Conekta.Dotnet6.Base;
using ConektaDotnet6.Values;

namespace ConektaDotnet6.Response
{
    public class Customer : Models.Customer, IConektaObject
    {
        public string id { get; set; }

        public string type { get; set; }

        public string @object { get; set; }

        public bool livemode { get; set; }

        public ConektaDatetime updated_at { get; set; }

        public new ConektaDotnet6.Response.PaymentSources payment_sources { get; set; }

        public Models.Customer GetCustomer()
        {
            var paymentSources = new List<Models.PaymentSource>();
            if (this.payment_sources != null)
            {
                paymentSources = this.payment_sources.data;
            }

            return new Models.Customer
            {
                CustomerId = this.id,
                Name = this.Name,
                Email = this.Email,
                Phone = this.Phone,
                Corporate = this.Corporate,
                PaymentSources = paymentSources.ToArray(),
                created_at = this.created_at,
                DefaultPaymentSourceId = this.DefaultPaymentSourceId,
                Deleted = this.Deleted

            };
        }
    }
}
