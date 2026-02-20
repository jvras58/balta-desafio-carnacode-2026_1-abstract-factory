using PaymentGateway.Abstractions;

namespace PaymentGateway.Gateways.Stripe;

public class StripeProcessor : IPaymentProcessor
{
    public string ProcessTransaction(decimal amount, string cardNumber)
    {
        Console.WriteLine($"Stripe: Processando ${amount}...");
        return $"STRIPE-{Guid.NewGuid().ToString()[..8].ToUpper()}";
    }
}
