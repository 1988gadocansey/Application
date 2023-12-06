using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicantPortal.Domain.ValueObjects;

[Keyless]
[NotMapped]
public record EmailAddress : ValueObject
{
    public string? Value { get; }

    public static EmailAddress Create(string? value)
    {
        return new EmailAddress(value);
    }

     

    public EmailAddress(string? value)
    {
        if (!value!.Contains("@")) throw new Exception("Email is invalid");
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length > 320)
        {
            throw new ArgumentOutOfRangeException("email address too long");
        }

        //more validations
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
