using PaymentGateway.Abstractions;
using PaymentGateway.Gateways.PagSeguro;

namespace PaymentGateway.Factories;

public class PagSeguroFactory : IPaymentFactory
{
    public IPaymentValidator CreateValidator() => new PagSeguroValidator();
    public IPaymentProcessor CreateProcessor() => new PagSeguroProcessor();
    public IPaymentLogger    CreateLogger()    => new PagSeguroLogger();
}
