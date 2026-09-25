using DDDStudy.Domain.ValueObjects;

namespace DDDStudy.Domain.Entities;

public class Customer
{
    public Customer(string name, string email)
    {
        Name = name;
        Email = new Email(email);
    }
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public Email Email { get; private set; }

    public void ChangeEmail(string newEmail)
    {
        Email = new Email(newEmail);
    }
}