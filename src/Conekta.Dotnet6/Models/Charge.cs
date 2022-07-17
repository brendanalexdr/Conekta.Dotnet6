using ConektaDotnet6.Values;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Models
{

    public class Charge
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created_at")]
        public ConektaDatetime CreatedAt { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("amount")]
        public ConektaAmount Amount { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        [JsonPropertyName("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("status")]
        public PaymentStatus Status { get; set; }

        [JsonPropertyName("paid_at")]
        public ConektaDatetime PaidAt { get; set; }

        [JsonPropertyName("fee")]
        public ConektaAmount Fee { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonIgnore]
        public bool IsPaid
        {

            get
            {

                return Status == PaymentStatus.Paid;

            }
        }

    }
}
