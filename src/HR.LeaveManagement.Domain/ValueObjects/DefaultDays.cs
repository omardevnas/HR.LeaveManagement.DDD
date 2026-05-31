using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain.ValueObjects;

public class DefaultDays : ValueObject
{
    public int Value { get; }

    private DefaultDays(int value)
    {
        Value = value;
    }

    public static DefaultDays Create(int value)
    {
        if (value < 1 || value > 365)
            throw new ArgumentException("Default days must be between 1 and 365.", nameof(value));

        return new DefaultDays(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator int(DefaultDays days) => days.Value;
}
