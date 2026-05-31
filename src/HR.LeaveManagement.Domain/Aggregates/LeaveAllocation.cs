using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Domain.Events;
using HR.LeaveManagement.Domain.ValueObjects;

namespace HR.LeaveManagement.Domain.Aggregates;

public class LeaveAllocation : AggregateRoot<Guid>
{
    public Guid LeaveTypeId { get; private set; }
    public EmployeeId EmployeeId { get; private set; } = null!;
    public AllocationPeriod Period { get; private set; } = null!;
    public int NumberOfDays { get; private set; }

    private LeaveAllocation() { } // For EF Core

    public static LeaveAllocation Grant(Guid id, Guid leaveTypeId,
        EmployeeId employeeId, AllocationPeriod period, int days)
    {
        if (days <= 0) throw new ArgumentException("Days must be positive.");
        
        var allocation = new LeaveAllocation
        {
            Id = id,
            LeaveTypeId = leaveTypeId,
            EmployeeId = employeeId,
            Period = period,
            NumberOfDays = days
        };
        allocation.Raise(new LeaveAllocated(id, leaveTypeId, employeeId.Value, days, period.Year, DateTimeOffset.UtcNow));
        return allocation;
    }

    public void AdjustDays(int newDays)
    {
        if (newDays <= 0) throw new ArgumentException("Days must be positive.");
        NumberOfDays = newDays;
        Raise(new LeaveAllocationAdjusted(Id, newDays, DateTimeOffset.UtcNow));
    }
}
