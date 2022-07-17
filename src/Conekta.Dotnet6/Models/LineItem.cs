using ConektaDotnet6.Values;

namespace ConektaDotnet6.Models
{
    public class LineItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ConektaAmount unit_price { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
        public bool shippable { get; set; }
        public string[] tags { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string parent_id { get; set; }
        

    }
}
