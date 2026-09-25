namespace PaymentContext.Domain.Entities;

public class Student
{
    public Student(string firstName, string lastName, string document, string email, string address)
    {
        FirstName = firstName;
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name cannot be empty.", nameof(firstName));
        LastName = lastName;
        Document = document;
        Email = email;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    private readonly IList<Subscription> _subscriptions = [];
    public IReadOnlyCollection<Subscription> Subscriptions { get => _subscriptions.AsReadOnly(); }

    public void AddSubscription(Subscription subscription)
    {
        foreach (var sub in _subscriptions) sub.Deactivate();

        _subscriptions.Add(subscription);
    }
}
