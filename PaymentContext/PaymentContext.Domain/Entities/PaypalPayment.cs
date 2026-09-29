using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PaypalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, EDocumentType document, Address address, Email email) :
Payment(paidDate, expireDate, total, totalPaid, payer, document, address, email)
{
    public string TransactionCode { get; private set; } = transactionCode;
}
