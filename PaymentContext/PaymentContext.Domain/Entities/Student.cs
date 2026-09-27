using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    public Student(Name name, Document document, Email email, Address address)
    {
        Name = name;
        Document = document;
        Address = address;
        Email = email;

        AddNotifications(name, document, email, address);
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    private readonly IList<Subscription> _subscriptions = [];
    public IReadOnlyCollection<Subscription> Subscriptions { get => _subscriptions.AsReadOnly(); }

    public void AddSubscription(Subscription subscription)
    {
        AddNotifications(new Contract<Subscription>()
            .Requires()
            .IsFalse(_subscriptions.Any(sub => sub.IsActive()), "Student.Subscription", "Cannot add an active subscription when there are existing subscriptions")
        );

        _subscriptions.Add(subscription);
    }
}
