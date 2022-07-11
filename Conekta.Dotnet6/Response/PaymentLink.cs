using Conekta.Dotnet6.Base;

namespace Conekta.Dotnet6.Response;

public class PaymentLink : Models.PaymentLink, IConektaObject
{
    public string id { get; set; }

    public string type { get; set; }

    public string @object { get; set; }

    public bool livemode { get; set; }

    public double created_at { get; set; }

    public double updated_at { get; set; }
}
