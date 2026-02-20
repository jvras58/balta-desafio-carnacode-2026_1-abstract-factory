using PaymentGateway.Abstractions;
using PaymentGateway.Factories;

namespace PaymentGateway.Registry;

/// <summary>
/// Registro central de gateways. Adicionar um novo gateway =
/// criar sua família de classes + uma linha aqui. Nada mais.
/// Princípio Open/Closed: aberto para extensão, fechado para modificação.
/// </summary>
public static class PaymentFactoryRegistry
{
    private static readonly Dictionary<string, IPaymentFactory> _factories =
        new(StringComparer.OrdinalIgnoreCase)
        {
            { "pagseguro",   new PagSeguroFactory()   },
            { "mercadopago", new MercadoPagoFactory() },
            { "stripe",      new StripeFactory()      },
        };

    public static IPaymentFactory Resolve(string gateway)
    {
        if (_factories.TryGetValue(gateway, out var factory))
            return factory;

        var available = string.Join(", ", _factories.Keys);
        throw new NotSupportedException(
            $"Gateway '{gateway}' não suportado. Disponíveis: {available}");
    }

    /// <summary>
    /// Permite registrar novos gateways em runtime (útil para plugins e testes).
    /// </summary>
    public static void Register(string gateway, IPaymentFactory factory) =>
        _factories[gateway] = factory;
}
