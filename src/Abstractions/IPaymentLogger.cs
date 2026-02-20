namespace PaymentGateway.Abstractions;

public interface IPaymentLogger
{
    void Log(string message);
}
