using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ApplicantPortal.Domain.ValueObjects;

[Keyless]
[NotMapped]
public record Money : ValueObject
{
    public static Money Create(string currency, decimal amount)
    {
        if (amount < 0)
        {
            throw new Exception("Invalid number for a money");
        }
        return new Money(currency, amount);
    }
    private Money(string currency, decimal amount)
    {
        if (amount < 0)
        {
            throw new Exception("Invalid number for a money");
        }
        this.Currency = currency;
        this.Amount = amount;
    }

    public string Currency { get; }
    public decimal Amount { get; }

    /*private bool Equals(Money? other)
    {
        if (object.ReferenceEquals(other, null)) return false;
        if (object.ReferenceEquals(other, this)) return true;
        return this.Currency.Equals(other.Currency) && this.Amount.Equals(other.Amount);
    }*/

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
    }

    /*public override bool Equals(object? obj)
    {
        return Equals(obj as Money);
    }*/
    public override int GetHashCode()
    {
        return this.Currency.GetHashCode() ^ this.Amount.GetHashCode();
    }
}
