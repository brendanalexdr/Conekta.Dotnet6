using Conekta.Dotnet6.Base;
using ConektaDotnet6.Models;
using ConektaDotnet6.Values;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Response
{
    public class Customer : ICustomer, IConektaObject
    {
        public string id { get; set; }

        public string type { get; set; }

        public string @object { get; set; }

        public bool livemode { get; set; }

        public ConektaDatetime updated_at { get; set; }

        public ConektaDatetime created_at { get; set; }

        public Response.PaymentSources payment_sources { get; set; }

        [JsonPropertyName("corporate")]
        public bool Corporate { get; set; }

        [JsonPropertyName("default_payment_source_id")]
        public string DefaultPaymentSourceId { get; set; }

        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        

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
                CreatedAt = this.created_at,
                DefaultPaymentSourceId = this.DefaultPaymentSourceId,
                Deleted = this.Deleted

            };
        }
    }
}
