using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain.ValueObjects;

public class AllocationPeriod : ValueObject
{
    public int Year { get; }

    private AllocationPeriod(int year)
    {
        Year = year;
    }

    public static AllocationPeriod Create(int year)
    {
        if (year < 2000 || year > 2100)
            throw new ArgumentException("Invalid allocation period.");

        return new AllocationPeriod(year);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Year;
    }

    public static implicit operator int(AllocationPeriod period) => period.Year;
}
