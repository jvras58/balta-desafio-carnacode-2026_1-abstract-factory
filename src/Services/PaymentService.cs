using PaymentGateway.Abstractions;

namespace PaymentGateway.Services;

/// <summary>
/// Orquestra o fluxo de pagamento usando apenas abstrações.
/// Não conhece nenhum gateway concreto — zero switch/case.
/// Responsabilidade Única: executar a sequência validar → processar → logar.
/// </summary>
public class PaymentService
{
    private readonly IPaymentValidator _validator;
    private readonly IPaymentProcessor _processor;
    private readonly IPaymentLogger    _logger;

    public PaymentService(IPaymentFactory factory)
    {
        _validator = factory.CreateValidator();
        _processor = factory.CreateProcessor();
        _logger    = factory.CreateLogger();
    }

    public void ProcessPayment(decimal amount, string cardNumber)
    {
        if (!_validator.ValidateCard(cardNumber))
        {
            _logger.Log($"Cartão inválido: {Mask(cardNumber)}");
            Console.WriteLine("Pagamento cancelado: cartão inválido.");
            return;
        }

        var transactionId = _processor.ProcessTransaction(amount, cardNumber);
        _logger.Log($"Transação concluída | ID: {transactionId} | Valor: {amount:C}");
    }

    /// <summary>
    /// Mascara o número do cartão para nunca expor dados sensíveis em logs.
    /// </summary>
    private static string Mask(string cardNumber) =>
        cardNumber.Length >= 4
            ? $"****-****-****-{cardNumber[^4..]}"
            : "****";
}
