using Conekta.Dotnet6.Base;
using ConektaDotnet6.Models;
using ConektaDotnet6.Values;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Response
{
    public class Order : IOrder, IConektaObject
    {
        public string id { get; set; }
        public string type { get; set; }
        public string @object { get; set; }
        public bool livemode { get; set; }

        public ConektaDatetime created_at { get; set; }
        public ConektaDatetime updated_at { get; set; }
        public Response.LineItems line_items { get; set; }
        public Response.Charges charges { get; set; }
        public Response.Returns returns { get; set; }
        public Response.Customer customer_info { get; set; }
        public JsonDocument shipping_lines { get; set; }

        [JsonPropertyName("amount")]
        public ConektaAmount Amount { get; set; }

        [JsonPropertyName("amount_refunded ")]
        public ConektaAmount AmountRefunded { get; set; }
        

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }


        [JsonPropertyName("metadata ")]
        public JsonDocument Metadata { get; set; }

        [JsonPropertyName("payment_status")]
        public PaymentStatus PaymentStatus { get; set; }

        [JsonPropertyName("pre_authorize")]
        public bool PreAuthorize { get; set; }


        public Models.Order GetOrder()
        {
            var _lineItms = new List<Models.LineItem>();
            if (this.line_items != null)
            {
                _lineItms = this.line_items.data;
            }
            var _charges = new List<Models.Charge>();
            if (this.charges != null)
            {
                _charges = this.charges.data;
            }
            var _returns = new List<Models.Return>();
            if (this.returns != null)
            {
                _returns = this.returns.data;
            }

            var ord = new Models.Order
            {

                OrderId = this.id,
                Amount = this.Amount,
                Currency = this.Currency,
                PaymentStatus = this.PaymentStatus,
                CustomerId = this.CustomerId,
                LineItems = _lineItms,
                Charges = _charges,
                CustomerInfo = this.customer_info.GetCustomer(),
                Returns = _returns,
                CreatedAt = this.created_at,
                UpdtedAt = this.updated_at,
                PreAuthorize = this.PreAuthorize,
                Metadata = this.Metadata,
                AmountRefunded = this.AmountRefunded,

            };
   
            return ord;

        }
    }
}
