using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveRequest.ValueObjects;

public class DateRange : Value<DateRange>
{
    public DateTime Start { get; }
    public DateTime End { get; }
    public int NumberOfDays => (End - Start).Days + 1;

    private DateRange(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public static DateRange Create(DateTime start, DateTime end)
    {
        if (start > end)
            throw new ArgumentException("Start date must be before or equal to end date.");

        return new DateRange(start, end);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}
