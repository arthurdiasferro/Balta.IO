namespace PaymentContext.Domain.Entities;

public class PaypalPayment : Payment
{
    public string TransactionCode { get; set; }
    public string Email { get; set; }
}
