using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicantPortal.Domain.ValueObjects;
[Keyless]
[NotMapped]
public record ApplicantName : ValueObject
{
    public string? FirstName { get; }
    public string? LastName { get; }
    public string? Othernames { get; }
    private ApplicantName(string? firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public static ApplicantName Create(string? FirstName, string? LastName, string Othernames)
    {
        return new ApplicantName(FirstName, LastName, Othernames);
    }
    private ApplicantName(string? firstName, string? lastName, string othernames)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Othernames = othernames;
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return Othernames;
    }




}
