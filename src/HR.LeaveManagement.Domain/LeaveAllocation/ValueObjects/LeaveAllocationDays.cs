using HR.LeaveManagement.Domain.Constants;
using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveAllocation.ValueObjects;

public class LeaveAllocationDays:Value<LeaveAllocationDays>
{
    public int Value { get; }

    public LeaveAllocationDays(int value)
    {
        Value = Create(value);
    }

    private LeaveAllocationDays Create(int value)
    {
        if(value < LeaveAllocationDefaultDaysRange.MinDays || value > LeaveAllocationDefaultDaysRange.MaxDays)
            throw new ArgumentException($"Leave allocation days must be between {LeaveAllocationDefaultDaysRange.MinDays} and {LeaveAllocationDefaultDaysRange.MaxDays}", nameof(value));
        
        return new LeaveAllocationDays(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator int(LeaveAllocationDays id) => id.Value;
}