using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain.ValueObjects;

public class EmployeeId : ValueObject
{
    public string Value { get; }

    private EmployeeId(string value)
    {
        Value = value;
    }

    public static EmployeeId Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Employee ID cannot be empty.", nameof(value));

        return new EmployeeId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(EmployeeId id) => id.Value;
}
