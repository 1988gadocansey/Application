using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicantPortal.Domain.ValueObjects;

public record Address : ValueObject
{
    private string? Street { get; set; }
    private string? City { get; set; }
    private string? State { get; set; }
    private string? Country { get; set; }
    private string? Gprs { get; set; }

    public Address() { }

    public Address(string? street, string? city, string? state, string? country, string? gprs)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        Gprs = gprs;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return Gprs;
    }
}
