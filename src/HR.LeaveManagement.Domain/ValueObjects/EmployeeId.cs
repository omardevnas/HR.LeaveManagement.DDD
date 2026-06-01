using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.ValueObjects;

public class EmployeeId : Value<EmployeeId>
{
    public Guid Value { get; }

    public EmployeeId(Guid value)
    {
        Value = Create(value);
    }

    private  EmployeeId Create(Guid value)
    {
        if (value == null || value == Guid.Empty)
            throw new ArgumentException("Employee ID cannot be empty.", nameof(value));

        return new EmployeeId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(EmployeeId id) => id.Value;
}
