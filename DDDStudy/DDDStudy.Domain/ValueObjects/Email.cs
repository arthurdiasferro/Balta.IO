using System.Text.RegularExpressions;

namespace DDDStudy.Domain.ValueObjects;

public class Email
{
    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new Exception("Email address cannot be null or empty.");
        if (!Regex.IsMatch(address, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            throw new Exception("Email address is not valid.");
        Address = address;
    }
    public string Address { get; set; }
}