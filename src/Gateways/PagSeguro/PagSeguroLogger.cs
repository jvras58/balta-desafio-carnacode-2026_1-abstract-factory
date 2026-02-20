using PaymentGateway.Abstractions;

namespace PaymentGateway.Gateways.PagSeguro;

public class PagSeguroLogger : IPaymentLogger
{
    public void Log(string message) =>
        Console.WriteLine($"[PagSeguro] {DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}");
}
