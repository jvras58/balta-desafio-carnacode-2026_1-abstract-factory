using PaymentGateway.Abstractions;
using PaymentGateway.Gateways.MercadoPago;

namespace PaymentGateway.Factories;

public class MercadoPagoFactory : IPaymentFactory
{
    public IPaymentValidator CreateValidator() => new MercadoPagoValidator();
    public IPaymentProcessor CreateProcessor() => new MercadoPagoProcessor();
    public IPaymentLogger    CreateLogger()    => new MercadoPagoLogger();
}
