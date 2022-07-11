namespace Conekta.Dotnet6.Models
{
    public class ShippingLine
    {
        public string id { get; set; }
        public int amount { get; set; }
        public string tracking_number { get; set; }
        public string carrier { get; set; }
        public string method { get; set; }
        public string parent_id { get; set; }

    }
}
