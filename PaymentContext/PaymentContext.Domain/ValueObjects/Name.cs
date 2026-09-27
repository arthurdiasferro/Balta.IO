using System.ComponentModel.DataAnnotations;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    [Required(ErrorMessage = "First name is required")]
    [MinLength(3, ErrorMessage = "First name must have at least 3 characters")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    [MinLength(3, ErrorMessage = "Last name must have at least 3 characters")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public string LastName { get; set; }
}