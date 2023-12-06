using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicantPortal.Domain.ValueObjects;
[Keyless]
[NotMapped]
public record IdCard : ValueObject
{

    public IdCard(string nationalIDType, string nationalIDNo)
    {
        if (nationalIDType is null)
        {
            throw new Exception("Invalid IDCard name");
        }
        this.NationalIDType = nationalIDType;
        this.NationalIDNo = nationalIDNo;
    }

    public static IdCard Create(string nationalIDType, string nationalIDNo)
    {
        if (nationalIDType is null)
        {
            throw new Exception("Invalid IDCard name");
        }
        return new IdCard(nationalIDNo, nationalIDType);
    }


    public string NationalIDType { get; }
    public string NationalIDNo { get; set; }

    public virtual bool Equals(IdCard? other)
    {
        if (object.ReferenceEquals(other, null)) return false;
        if (object.ReferenceEquals(other, this)) return true;
        return this.NationalIDType.Equals(other.NationalIDType) && this.NationalIDNo!.Equals(other.NationalIDNo);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return NationalIDNo;
    }

    

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), NationalIDType, NationalIDType);
    }
}
