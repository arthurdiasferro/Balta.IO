using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Student _student;
    private readonly Subscription _subscription;
    private readonly Name _name;
    private readonly EDocumentType _document;
    private readonly Email _email;
    private readonly Address _address;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new EDocumentType("12332112332", Domain.Enums.EDocumentType.CPF);
        _email = new Email("bruce@wayne.com");
        _address = new Address("Street", "5", "Neighborhood", "City", "State", "Country", "ZipCode");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(DateTime.Now.AddYears(1));
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PaypalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 100, 100, "Wayne Corp", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
        Assert.IsFalse(_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenHadNoActiveSubscription()
    {
        Assert.IsTrue(_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);
        Assert.IsFalse(_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSucessWhenAddSubscription()
    {
        var payment = new PaypalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 100, 100, "Wayne Corp", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        Assert.IsTrue(_student.IsValid);
    }
}
