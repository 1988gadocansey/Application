namespace ApplicantPortal.Application.Common.Exceptions;

public class AggregateOutOfRangeException(int aggregateValue) : Exception
{
    private int AggregateValue { get; } = aggregateValue;

    public override string Message
    {
        get
        {
            return $"Aggregate value {AggregateValue} is out of range. ";
        }
    }
}
