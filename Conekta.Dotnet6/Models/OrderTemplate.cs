namespace Conekta.Dotnet6.Models;

public class OrderTemplate
{
    public LineItem[] line_items { get; set; }
    public string currency { get; set; }
    public CustomerInfoMinimal customer_info { get; set; }

    public Metadata metadata { get; set; }
}
