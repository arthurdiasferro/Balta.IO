using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;

        AddNotifications(new Contract<Address>()
            .Requires()
            .IsNotNullOrEmpty(Street, "Address.Street", "Street is required")
            .IsNotNullOrEmpty(Number, "Address.Number", "Number is required")
            .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "Neighborhood is required")
            .IsNotNullOrEmpty(City, "Address.City", "City is required")
            .IsNotNullOrEmpty(State, "Address.State", "State is required")
            .IsNotNullOrEmpty(Country, "Address.Country", "Country is required")
            .IsNotNullOrEmpty(ZipCode, "Address.ZipCode", "ZipCode is required")
        );
    }

    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}
