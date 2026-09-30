using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("invalid", Domain.Enums.EDocumentType.CNPJ);
        Assert.IsFalse(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("24392182000128", Domain.Enums.EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("invalid", Domain.Enums.EDocumentType.CPF);
        Assert.IsFalse(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsValid()
    {
        var doc = new Document("12345678909", Domain.Enums.EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}
