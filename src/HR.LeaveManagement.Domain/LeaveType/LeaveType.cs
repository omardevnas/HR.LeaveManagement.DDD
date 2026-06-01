using HR.LeaveManagement.Domain.DomainObjectsAbstractions;
using HR.LeaveManagement.Domain.LeaveType.Events;
using HR.LeaveManagement.Domain.LeaveType.ValueObjects;
using HR.LeaveManagement.Domain.ValueObjects;

namespace HR.LeaveManagement.Domain.LeaveType;

public class LeaveType : AggregateRoot<LeaveTypeId>
{
    public LeaveTypeName Name { get; private set; } = null!;
    public LeaveDays LeaveDays { get; private set; } = null!;
// LeaveTypeRule maybe we should add it here
    private LeaveType() { }
    
    public LeaveType(LeaveTypeId id, LeaveTypeName name, LeaveDays defaultDays)
    {
        Apply(new LeaveTypeCreated(id, name, defaultDays, DateTimeOffset.UtcNow));
    }

    public void Create(LeaveTypeId id, LeaveTypeName name, LeaveDays defaultDays)
    {
        Apply(new LeaveTypeCreated(id, name, defaultDays, DateTimeOffset.UtcNow));
    }

    public void UpdateDetails(LeaveTypeName name, LeaveDays defaultDays)
    {
        Apply(new LeaveTypeUpdated(Id, name, defaultDays, DateTimeOffset.UtcNow));
    }
    // AddRule?

    protected override void EnsureValidState()
    {
        var valid = Id != Guid.Empty &&
                     Name != null &&
                     LeaveDays != null;

        if (!valid)
            throw new InvalidOperationException("Post-checks failed in LeaveType aggregate.");
    }

    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case LeaveTypeCreated e:
                Id = new LeaveTypeId(e.Id);
                Name = LeaveTypeName.Create(e.Name);
                LeaveDays = new LeaveDays(e.DefaultDays);
                break;
            case LeaveTypeUpdated e:
                Name = LeaveTypeName.Create(e.Name);
                LeaveDays = new LeaveDays(e.DefaultDays);
                break;
        }
    }
}
