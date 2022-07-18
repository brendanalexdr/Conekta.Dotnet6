using CSharpFunctionalExtensions;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Values;

[JsonConverter(typeof(ConektaEventTypeJsonConverter))]
public class ConektaEventType : ValueObject<ConektaEventType>
{

    public string Value { get; protected set; }

    protected ConektaEventType()
    {

    }

    protected ConektaEventType(string value)
    {
        Value = value;
    }

    public static ConektaEventType Create(string value)
    {
        if (value == null)
        {
            return new ConektaEventType
            {
                Value = "-"
            };
        } else
        {
            return new ConektaEventType
            {
                Value = value
            };

        }
    }

    protected override bool EqualsCore(ConektaEventType other)
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

    public readonly static ConektaEventType ChargeCreated = new ConektaEventType("charge.created");
    public readonly static ConektaEventType ChargePaid = new ConektaEventType("charge.paid");
    public readonly static ConektaEventType ChargeUnderFraudReview = new ConektaEventType("charge.under_fraud_review");
    public readonly static ConektaEventType ChargeFraudulent = new ConektaEventType("charge.fraudulent");
    public readonly static ConektaEventType ChargeRefunded = new ConektaEventType("charge.refunded");
    public readonly static ConektaEventType ChargePreauthorized = new ConektaEventType("charge.preauthorized");
    public readonly static ConektaEventType ChargeDeclined = new ConektaEventType("charge.declined");
    public readonly static ConektaEventType ChargeCanceled = new ConektaEventType("charge.canceled");
    public readonly static ConektaEventType ChargeReversed = new ConektaEventType("charge.reversed");
    public readonly static ConektaEventType ChargePendingConfirmation = new ConektaEventType("charge.pending_confirmation");
    public readonly static ConektaEventType ChargeExpired = new ConektaEventType("charge.expired");
    public readonly static ConektaEventType CustomerCreated = new ConektaEventType("customer.created");
    public readonly static ConektaEventType CustomerUpdated = new ConektaEventType("customer.updated");
    public readonly static ConektaEventType CustomerDeleted = new ConektaEventType("customer.deleted");
    public readonly static ConektaEventType WebhookCreated = new ConektaEventType("webhook.created");
    public readonly static ConektaEventType WebhookUpdated = new ConektaEventType("webhook.updated");
    public readonly static ConektaEventType WebhookDeleted = new ConektaEventType("webhook.deleted");
    public readonly static ConektaEventType ChargeChargebackCreated = new ConektaEventType("charge.chargeback.created");
    public readonly static ConektaEventType ChargeChargebackUpdated = new ConektaEventType("charge.chargeback.updated");
    public readonly static ConektaEventType ChargeChargebackUnderReview = new ConektaEventType("charge.chargeback.under_review");
    public readonly static ConektaEventType ChargeChargebackLost = new ConektaEventType("charge.chargeback.lost");
    public readonly static ConektaEventType ChargeChargebackWon = new ConektaEventType("charge.chargeback.won");
    public readonly static ConektaEventType PayoutCreated = new ConektaEventType("payout.created");
    public readonly static ConektaEventType PayoutRetrying = new ConektaEventType("payout.retrying");
    public readonly static ConektaEventType PayoutPaidOut = new ConektaEventType("payout.paid_out");
    public readonly static ConektaEventType PayoutFailed = new ConektaEventType("payout.failed");
    public readonly static ConektaEventType PlanCreated = new ConektaEventType("plan.created");
    public readonly static ConektaEventType PlanUpdated = new ConektaEventType("plan.updated");
    public readonly static ConektaEventType PlanDeleted = new ConektaEventType("plan.deleted");
    public readonly static ConektaEventType SubscriptionCreated = new ConektaEventType("subscription.created");
    public readonly static ConektaEventType SubscriptionPaused = new ConektaEventType("subscription.paused");
    public readonly static ConektaEventType SubscriptionResumed = new ConektaEventType("subscription.resumed");
    public readonly static ConektaEventType SubscriptionCanceled = new ConektaEventType("subscription.canceled");
    public readonly static ConektaEventType SubscriptionExpired = new ConektaEventType("subscription.expired");
    public readonly static ConektaEventType SubscriptionUpdated = new ConektaEventType("subscription.updated");
    public readonly static ConektaEventType SubscriptionPaid = new ConektaEventType("subscription.paid");
    public readonly static ConektaEventType SubscriptionPaymentFailed = new ConektaEventType("subscription.payment_failed");
    public readonly static ConektaEventType PayeeCreated = new ConektaEventType("payee.created");
    public readonly static ConektaEventType PayeeUpdated = new ConektaEventType("payee.updated");
    public readonly static ConektaEventType PayeeDeleted = new ConektaEventType("payee.deleted");
    public readonly static ConektaEventType PayeePayoutMethodCreated = new ConektaEventType("payee.payout_method.created");
    public readonly static ConektaEventType PayeePayoutMethodUpdated = new ConektaEventType("payee.payout_method.updated");
    public readonly static ConektaEventType PayeePayoutMethodDeleted = new ConektaEventType("payee.payout_method.deleted");
    public readonly static ConektaEventType ChargeScoreUpdated = new ConektaEventType("charge.score_updated");
    public readonly static ConektaEventType ReceiptCreated = new ConektaEventType("receipt.created");
    public readonly static ConektaEventType OrderCanceled = new ConektaEventType("order.canceled");
    public readonly static ConektaEventType OrderChargedBack = new ConektaEventType("order.charged_back");
    public readonly static ConektaEventType OrderCreated = new ConektaEventType("order.created");
    public readonly static ConektaEventType OrderExpired = new ConektaEventType("order.expired");
    public readonly static ConektaEventType OrderFraudulent = new ConektaEventType("order.fraudulent");
    public readonly static ConektaEventType OrderUnderFraudReview = new ConektaEventType("order.under_fraud_review");
    public readonly static ConektaEventType OrderPaid = new ConektaEventType("order.paid");
    public readonly static ConektaEventType OrderPartiallyRefunded = new ConektaEventType("order.partially_refunded");
    public readonly static ConektaEventType OrderPendingPayment = new ConektaEventType("order.pending_payment");
    public readonly static ConektaEventType OrderPreAuthorized = new ConektaEventType("order.pre_authorized");
    public readonly static ConektaEventType OrderRefunded = new ConektaEventType("order.refunded");
    public readonly static ConektaEventType OrderUpdated = new ConektaEventType("order.updated");
    public readonly static ConektaEventType OrderVoided = new ConektaEventType("order.voided");   
    public readonly static ConektaEventType WebhookPing = new ConektaEventType("webhook_ping");
}
