namespace PaymentGateway.Abstractions;

/// <summary>
/// Abstract Factory: garante que validator, processor e logger
/// criados sempre pertençam à mesma família de gateway.
/// </summary>
public interface IPaymentFactory
{
    IPaymentValidator CreateValidator();
    IPaymentProcessor CreateProcessor();
    IPaymentLogger    CreateLogger();
}
