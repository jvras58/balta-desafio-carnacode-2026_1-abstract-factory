using PaymentGateway.Abstractions;
using PaymentGateway.Gateways.Stripe;

namespace PaymentGateway.Factories;

public class StripeFactory : IPaymentFactory
{
    public IPaymentValidator CreateValidator() => new StripeValidator();
    public IPaymentProcessor CreateProcessor() => new StripeProcessor();
    public IPaymentLogger    CreateLogger()    => new StripeLogger();
}
