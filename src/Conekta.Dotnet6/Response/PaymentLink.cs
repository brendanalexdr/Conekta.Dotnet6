using Conekta.Dotnet6.Base;
using ConektaDotnet6.Values;

namespace ConektaDotnet6.Response;

public class PaymentLink : Models.PaymentLink, IConektaObject
{
    public string type { get; set; }

    public string @object { get; set; }

    public bool livemode { get; set; }

    public ConektaDatetime created_at { get; set; }

    public ConektaDatetime updated_at { get; set; }


}
