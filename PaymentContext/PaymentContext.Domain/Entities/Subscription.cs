using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    public Subscription(DateTime expireDate)
    {
        CreateDate = DateTime.UtcNow;
        LastUpdateDate = DateTime.UtcNow;
        ExpireDate = expireDate;
        Active = true;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public bool Active { get; private set; }
    private readonly IList<Payment> _payments = [];
    public IReadOnlyCollection<Payment> Payments { get => _payments.AsReadOnly(); }

    public void AddPayment(Payment payment)
    {
        AddNotifications(new Contract<Payment>()
            .Requires()
            .IsLowerThan(payment.PaidDate, DateTime.Now, "Subscription.Payment", "Payment date must be in the past")
        );

        _payments.Add(payment);
    }

    public void Activate()
    {
        Active = true;
        LastUpdateDate = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Active = false;
        LastUpdateDate = DateTime.UtcNow;
    }

    public bool IsActive()
    {
        return Active;
    }

}
