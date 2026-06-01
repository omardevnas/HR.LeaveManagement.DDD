using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveRequest.ValueObjects;

public class LeaveRequestId:Value<LeaveRequestId>
{
    public Guid Value { get; }

    public LeaveRequestId(Guid value)
    {
        Value = Create(value);
    }

    private  LeaveRequestId Create(Guid value)
    {
        if (value == null || value == Guid.Empty)
            throw new ArgumentException("LeaveType ID cannot be empty.", nameof(value));

        return new LeaveRequestId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(LeaveRequestId id) => id.Value;   
}