using Conekta.Dotnet6.Base;
using Conekta.Dotnet6.Values;

namespace Conekta.Dotnet6.Response;

public class PaymentLink : Models.PaymentLink, IConektaObject
{
    public string type { get; set; }

    public string @object { get; set; }

    public bool livemode { get; set; }

    public UnixTimestamp created_at { get; set; }

    public UnixTimestamp updated_at { get; set; }


}
