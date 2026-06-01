using HR.LeaveManagement.Domain.DomainObjectsAbstractions;
using HR.LeaveManagement.Domain.LeaveType.Constants;

namespace HR.LeaveManagement.Domain.LeaveType.ValueObjects;

public class LeaveTypeName : Value<LeaveTypeName>
{
    public string Value { get; }

    private LeaveTypeName(string value)
    {
        Value = value;
    }

    public static LeaveTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Leave type name cannot be empty.", nameof(value));

        if (value.Length > LeaveTypeConsts.MaxNameLength)
            throw new ArgumentException("Leave type name cannot exceed 50 characters.", nameof(value));

        return new LeaveTypeName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(LeaveTypeName name) => name.Value;
}
