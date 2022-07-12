using System.Text.Json;

namespace Conekta.Dotnet6.Models;

public class Order
{
    public string id { get; set; }
    public int amount { get; set; }
    public string currency { get; set; }
    public string payment_status { get; set; }
    public List<LineItem> line_items { get; set; }
    public Customer customer_info { get; set; }
    public List<Charge> charges { get; set; }
    public List<Return> returns { get; set; }
    public List<ShippingLine> shipping_lines { get; set; }
    public string customer_id { get; set; }
    public JsonDocument metadata { get; set; }
    public bool pre_authorize { get; set; }
    public string order_id { get; set; }
    public int paid_at { get; set; }
    public int created_at { get; set; }

}
