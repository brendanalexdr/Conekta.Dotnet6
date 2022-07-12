using Conekta.Dotnet6.Base;

namespace Conekta.Dotnet6.Response;

public class PaymentLink : Models.PaymentLink, IConektaObject
{
    public string type { get; set; }

    public string @object { get; set; }

    public bool livemode { get; set; }

    public int created_at { get; set; }

    public int updated_at { get; set; }
}
