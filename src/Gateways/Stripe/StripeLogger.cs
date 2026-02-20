using PaymentGateway.Abstractions;

namespace PaymentGateway.Gateways.Stripe;

public class StripeLogger : IPaymentLogger
{
    public void Log(string message) =>
        Console.WriteLine($"[Stripe] {DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}");
}
