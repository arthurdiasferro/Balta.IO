using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment(string cardHolderName, string cardNumber, string lastTransactionNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, EDocumentType document, Address address, Email email) :
Payment(paidDate, expireDate, total, totalPaid, payer, document, address, email)
{
    public string CardHolderName { get; private set; } = cardHolderName;
    public string CardNumber { get; private set; } = cardNumber;
    public string LastTransactionNumber { get; private set; } = lastTransactionNumber;
}
