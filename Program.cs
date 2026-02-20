using PaymentGateway.Registry;
using PaymentGateway.Services;

Console.WriteLine("=== Sistema de Pagamentos Multi-Gateway ===\n");

RunPayment("pagseguro",   150.00m, "1234567890123456");
Console.WriteLine();

RunPayment("mercadopago", 200.00m, "5234567890123456");
Console.WriteLine();

RunPayment("stripe",      300.00m, "4234567890123456");
Console.WriteLine();

// Cartão inválido para o gateway (MercadoPago exige início com "5")
RunPayment("mercadopago", 99.99m, "1111111111111111");
Console.WriteLine();

// Gateway não cadastrado — tratado com exceção clara
try
{
    RunPayment("paypal", 100.00m, "9999999999999999");
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"[Erro] {ex.Message}");
}

static void RunPayment(string gateway, decimal amount, string card)
{
    var factory = PaymentFactoryRegistry.Resolve(gateway);
    var service = new PaymentService(factory);
    service.ProcessPayment(amount, card);
}
