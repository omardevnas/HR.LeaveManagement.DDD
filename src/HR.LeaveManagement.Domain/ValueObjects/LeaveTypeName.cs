using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain.ValueObjects;

public class LeaveTypeName : ValueObject
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

        if (value.Length > 50)
            throw new ArgumentException("Leave type name cannot exceed 50 characters.", nameof(value));

        return new LeaveTypeName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(LeaveTypeName name) => name.Value;
}
