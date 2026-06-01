using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveAllocation.ValueObjects;

public class AllocationPeriod : Value<AllocationPeriod>
{
    public int Year { get; }

    public AllocationPeriod(int year)
    {
        Year = year;
    }

    private AllocationPeriod Create(int year)
    {
        var currentYear = DateTime.UtcNow.Year;
        if (year < currentYear || year > currentYear)
            throw new ArgumentException("Invalid allocation period.");

        return new AllocationPeriod(year);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Year;
    }

    public static implicit operator int(AllocationPeriod period) => period.Year;
}
