using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
namespace PaymentContext.Domain.ValueObjects;

public class EDocumentType : ValueObject
{
    public string Number { get; private set; }
    public Enums.EDocumentType Type { get; private set; }
    public EDocumentType(string number, Enums.EDocumentType type)
    {
        Number = number;
        Type = type;

        AddNotifications(new Contract<EDocumentType>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Invalid document number")
        );
    }

    private bool Validate()
    {
        if (Type == Enums.EDocumentType.CPF && Number.Length == 11)
        {
            // Validate CPF number format
            return true;
        }
        else if (Type == Enums.EDocumentType.CNPJ && Number.Length == 14)
        {
            // Validate CNPJ number format
            return true;
        }
        return false;
    }
}
