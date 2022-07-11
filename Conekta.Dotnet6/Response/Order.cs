using Conekta.Dotnet6.Base;
using System.Text.Json;

namespace Conekta.Dotnet6.Response
{
    public class Order : Conekta.Dotnet6.Models.Order, IConektaObject
    {
        public string id { get; set; }
        public string type { get; set; }
        public string @object { get; set; }
        public bool livemode { get; set; }
        public double created_at { get; set; }
        public double updated_at { get; set; }
        public LineItems line_items { get; set; }
        public Charges charges { get; set; }
        public Returns returns { get; set; }
        public Customer customer_info { get; set; }
        public JsonDocument shipping_lines { get; set; }

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

                id = this.id,
                amount = this.amount,
                currency = this.currency,
                payment_status = this.payment_status,
                customer_id = this.customer_id,
                line_items = _lineItms,
                charges = _charges,
                customer_info = this.customer_info.GetCustomer(),
                returns = _returns
            };
   
            return ord;

        }
    }
}
