namespace PaymentContext.Domain.Entities;

public class CreditPayment : Payment
{
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }
}
