using PaymentGateway.Abstractions;

namespace PaymentGateway.Gateways.MercadoPago;

public class MercadoPagoValidator : IPaymentValidator
{
    public bool ValidateCard(string cardNumber)
    {
        Console.WriteLine("MercadoPago: Validando cartão...");
        return cardNumber.Length == 16 && cardNumber.StartsWith("5");
    }
}
