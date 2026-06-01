using HR.LeaveManagement.Domain.Constants;
using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.ValueObjects;

public class LeaveDays : Value<LeaveDays>
{
    public int Value { get; }

    public LeaveDays(int value)
    {
        Value = Create(value);
    }

    private static LeaveDays Create(int value)
    {
        if (value < LeaveAllocationDefaultDaysRange.MinDays || value > LeaveAllocationDefaultDaysRange.MaxDays)
            throw new ArgumentException($"Default days must be between {LeaveAllocationDefaultDaysRange.MinDays} and {LeaveAllocationDefaultDaysRange.MaxDays}.", nameof(value));

        return new LeaveDays(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator int(LeaveDays days) => days.Value;
}
