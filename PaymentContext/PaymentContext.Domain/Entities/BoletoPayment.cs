using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment(string barCode, Email email, string boletoNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, EDocumentType document, Address address) :
Payment(paidDate, expireDate, total, totalPaid, payer, document, address, email)
{
    public string BarCode { get; private set; } = barCode;
    public string BoletoNumber { get; private set; } = boletoNumber;
}
