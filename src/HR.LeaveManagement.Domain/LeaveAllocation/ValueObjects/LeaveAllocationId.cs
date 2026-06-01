using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveAllocation.ValueObjects;

public class LeaveAllocationId:Value<LeaveAllocationId>
{
    public Guid Value { get; }

    public LeaveAllocationId(Guid value)
    {
        Value = Create(value);
    }

    private LeaveAllocationId Create(Guid value)
    {
        if (value == null && value == Guid.Empty)
            throw new ArgumentException("Allocation ID cannot be empty.", nameof(value));

        return new LeaveAllocationId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(LeaveAllocationId id) => id.Value;
}