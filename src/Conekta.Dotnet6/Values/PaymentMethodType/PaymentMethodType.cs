using CSharpFunctionalExtensions;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Values;

[JsonConverter(typeof(PaymentMethodTypeJsonConverter))]
public class PaymentMethodType : ValueObject<PaymentMethodType>
{
    public readonly static PaymentMethodType Card = new PaymentMethodType("card");
    public readonly static PaymentMethodType OxxoCash = new PaymentMethodType("oxxo_cash");
    public readonly static PaymentMethodType Cash = new PaymentMethodType("cash");
    public readonly static PaymentMethodType Spei = new PaymentMethodType("spei");


    public bool IsEmpty
    {

        get
        {

            return Value == "-";
        }

    }

    public string Value { get; protected set; }

    protected PaymentMethodType()
    {


    }

    protected PaymentMethodType(string value)
    {
        Value = value;

    }

    public static PaymentMethodType Create(string value)
    {

        switch(value.ToLower())
        {

            case "card":
                {
                    return PaymentMethodType.Card;

                    
                }
            case "oxxo_cash":
                {
                    return PaymentMethodType.OxxoCash;


                }
            case "cash":
                {
                    return PaymentMethodType.Cash;


                }
            case "spei":
                {
                    return PaymentMethodType.Spei;


                }

        }
        return new PaymentMethodType("-");

    }

    protected override bool EqualsCore(PaymentMethodType other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
