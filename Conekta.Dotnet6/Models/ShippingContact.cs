
namespace Conekta.Dotnet6.Models
{
    public class ShippingContact
    {
        public string id { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string receiver { get; set; }
        public string between_streets { get; set; }
        public Address address { get; set; }
        public string parent_id { get; set; }

    }
}
