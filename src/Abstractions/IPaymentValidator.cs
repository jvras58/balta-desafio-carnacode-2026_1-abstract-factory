namespace PaymentGateway.Abstractions;

public interface IPaymentValidator
{
    bool ValidateCard(string cardNumber);
}
