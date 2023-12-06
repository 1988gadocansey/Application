using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ApplicantPortal.Domain.ValueObjects;
[Keyless]
[NotMapped]
public record PhoneNumber : ValueObject
{
    private string? AreaCode { get; }
    private string? Number { get; }
    private PhoneNumber(string? areaCode) {
        AreaCode = areaCode;
    }
    public PhoneNumber(string? number, string? areaCode)
    {
        // AreaCode = areaCode;
        Number = number;
        AreaCode = areaCode;
    }
    public static PhoneNumber Create(string? number)
    {
        return new PhoneNumber(number);
    }
    /*   public string AreaCode { get; private set; }
      public string Number { get; private set; } */

    public string FullNumber()
    {
        // return $"{AreaCode} {Number}";
        return $"{Number}";
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return AreaCode;
        yield return Number;
    }
}
