using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Domain.Events;
using HR.LeaveManagement.Domain.ValueObjects;

namespace HR.LeaveManagement.Domain.Aggregates;

public class LeaveType : AggregateRoot<Guid>
{
    public LeaveTypeName Name { get; private set; } = null!;
    public DefaultDays DefaultDays { get; private set; } = null!;

    private LeaveType() { } // For EF Core

    public static LeaveType Create(Guid id, string name, int defaultDays)
    {
        var leaveType = new LeaveType
        {
            Id = id,
            Name = LeaveTypeName.Create(name),
            DefaultDays = DefaultDays.Create(defaultDays)
        };
        leaveType.Raise(new LeaveTypeCreated(id, name, defaultDays, DateTimeOffset.UtcNow));
        return leaveType;
    }

    public void UpdateDetails(string name, int defaultDays)
    {
        Name = LeaveTypeName.Create(name);
        DefaultDays = DefaultDays.Create(defaultDays);
        Raise(new LeaveTypeUpdated(Id, name, defaultDays, DateTimeOffset.UtcNow));
    }
}
