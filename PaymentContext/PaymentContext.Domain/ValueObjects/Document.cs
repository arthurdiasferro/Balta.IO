using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;

        AddNotifications(new Contract<Document>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Invalid document number")
        );
    }

    private bool Validate()
    {
        if (Type == EDocumentType.CPF && Number.Length == 11)
        {
            // Validate CPF number format
            return true;
        }
        else if (Type == EDocumentType.CNPJ && Number.Length == 14)
        {
            // Validate CNPJ number format
            return true;
        }
        return false;
    }
}
