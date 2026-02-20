using PaymentGateway.Abstractions;

namespace PaymentGateway.Gateways.MercadoPago;

public class MercadoPagoLogger : IPaymentLogger
{
    public void Log(string message) =>
        Console.WriteLine($"[MercadoPago] {DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}");
}
