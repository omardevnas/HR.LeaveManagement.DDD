using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveType.ValueObjects;

public class LeaveTypeId:Value<LeaveTypeId>
{
    public Guid Value { get; }

    public LeaveTypeId(Guid value)
    {
        Value = Create(value);
    }

    private  LeaveTypeId Create(Guid value)
    {
        if (value == null || value == Guid.Empty)
            throw new ArgumentException("LeaveType ID cannot be empty.", nameof(value));

        return new LeaveTypeId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(LeaveTypeId id) => id.Value;
}