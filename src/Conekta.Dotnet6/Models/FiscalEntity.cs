namespace Conekta.Dotnet6.Models
{
    public class FiscalEntity
    {
        public string id { get; set; }
        public string tax_id { get; set; }
        public string company_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
        public string parent_id { get; set; }

    }
}