namespace PaymentGateway.Abstractions;

public interface IPaymentProcessor
{
    string ProcessTransaction(decimal amount, string cardNumber);
}
