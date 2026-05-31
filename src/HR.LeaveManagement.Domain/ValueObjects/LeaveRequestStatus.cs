using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain.ValueObjects;

public class LeaveRequestStatus : ValueObject
{
    public static readonly LeaveRequestStatus Pending = new("Pending");
    public static readonly LeaveRequestStatus Approved = new("Approved");
    public static readonly LeaveRequestStatus Rejected = new("Rejected");
    public static readonly LeaveRequestStatus Cancelled = new("Cancelled");

    public string Value { get; }

    private LeaveRequestStatus(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(LeaveRequestStatus status) => status.Value;
}
