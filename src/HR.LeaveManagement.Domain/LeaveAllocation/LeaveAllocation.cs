using HR.LeaveManagement.Domain.DomainObjectsAbstractions;
using HR.LeaveManagement.Domain.LeaveAllocation.Events;
using HR.LeaveManagement.Domain.LeaveAllocation.ValueObjects;
using HR.LeaveManagement.Domain.LeaveType.Constants;
using HR.LeaveManagement.Domain.ValueObjects;

namespace HR.LeaveManagement.Domain.LeaveAllocation;

public class LeaveAllocation : AggregateRoot<LeaveAllocationId>
{
    public Guid LeaveTypeId { get; private set; }
    public EmployeeId EmployeeId { get; private set; } 
    public AllocationPeriod Period { get; private set; } 
    public LeaveAllocationDays NumberOfDays { get; private set; }

    private LeaveAllocation() { }

    private  LeaveAllocation(LeaveAllocationId id, Guid leaveTypeId,
        EmployeeId employeeId, AllocationPeriod period, LeaveAllocationDays days)
    {
        Apply(new LeaveAllocated(id, leaveTypeId, employeeId, days, period, DateTimeOffset.UtcNow));
    }
    
    public void Grant(LeaveAllocationId id, Guid leaveTypeId,
        EmployeeId employeeId, AllocationPeriod period, LeaveAllocationDays days)
    {
        Apply(new LeaveAllocated(id, leaveTypeId, employeeId, days, period, DateTimeOffset.UtcNow));
        
    }

    public void AdjustDays(LeaveAllocationDays newDays)
    {
        Apply(new LeaveAllocationAdjusted(Id, newDays, DateTimeOffset.UtcNow));
    }

    protected override void EnsureValidState()
    {
        var valid = Id != Guid.Empty &&
                     LeaveTypeId != Guid.Empty &&
                     EmployeeId != null &&
                     Period != null &&
                     NumberOfDays > 0;

        if (!valid)
            throw new InvalidOperationException("Post-checks failed in LeaveAllocation aggregate.");
    }

    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case LeaveAllocated e:
                Id = new LeaveAllocationId(e.AllocationId);
                LeaveTypeId = e.LeaveTypeId;
                EmployeeId = new EmployeeId(e.EmployeeId);
                Period = new AllocationPeriod(e.Year);
                NumberOfDays = new LeaveAllocationDays(e.Days);
                break;
            case LeaveAllocationAdjusted e:
                NumberOfDays = new LeaveAllocationDays(e.NewDays);
                break;
        }
    }
}
