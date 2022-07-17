using CSharpFunctionalExtensions;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Values;

[JsonConverter(typeof(PaymentStatusJsonConverter))]
public class PaymentStatus : ValueObject<PaymentStatus>
{
    public readonly static PaymentStatus Pending = new PaymentStatus("pending_payment");
    public readonly static PaymentStatus Declined = new PaymentStatus("declined");
    public readonly static PaymentStatus Expired = new PaymentStatus("expired");
    public readonly static PaymentStatus Paid = new PaymentStatus("paid");
    public readonly static PaymentStatus Refunded = new PaymentStatus("refunded");
    public readonly static PaymentStatus PartiallyRefunded = new PaymentStatus("partially_refunded");
    public readonly static PaymentStatus ChargedBack = new PaymentStatus("charged_back");
    public readonly static PaymentStatus PreAuthorized = new PaymentStatus("pre_authorized");
    public readonly static PaymentStatus Voided = new PaymentStatus("voided");

    public bool IsEmpty
    {
        get
        {
            return Value == "-";
        }
    }

    public string Value { get; protected set; }

    protected PaymentStatus() { }


    protected PaymentStatus(string value) {

        Value = value;
    
    }

    public static PaymentStatus Create(string value)
    {
        switch(value)
        {

            case "pending_payment":
                {

                    return PaymentStatus.Pending;
                }
            case "declined":
                {

                    return PaymentStatus.Declined;
                }
            case "expired":
                {

                    return PaymentStatus.Expired;
                }
            case "paid":
                {

                    return PaymentStatus.Paid;
                }
            case "refunded":
                {

                    return PaymentStatus.Refunded;
                }
            case "partially_refunded":
                {

                    return PaymentStatus.PartiallyRefunded;
                }
            case "charged_back":
                {

                    return PaymentStatus.ChargedBack;
                }
            case "pre_authorized":
                {

                    return PaymentStatus.PreAuthorized;
                }
            case "voided":
                {

                    return PaymentStatus.Voided;
                }
        }


        return new PaymentStatus("-");

    }

    protected override bool EqualsCore(PaymentStatus other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
}
