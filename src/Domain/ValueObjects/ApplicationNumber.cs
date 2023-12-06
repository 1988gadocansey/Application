using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ApplicantPortal.Domain.ValueObjects;
[Keyless]
[NotMapped]
public record ApplicationNumber : ValueObject
{
    public long ApplicantNumber { get; }
    public static ApplicationNumber Create(long ApplicantNumber)
    {
        return new ApplicationNumber(ApplicantNumber);
    }
    private ApplicationNumber(long applicantNumber)
    {
        ApplicantNumber = applicantNumber;
    }
    private ApplicationNumber() { }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ApplicantNumber;
    }
}
