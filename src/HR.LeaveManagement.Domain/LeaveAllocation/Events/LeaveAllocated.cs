using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveAllocation.Events;

public record LeaveAllocated(
    Guid AllocationId,
    Guid LeaveTypeId,
    Guid EmployeeId,
    int Days,
    int Year,
    DateTimeOffset OccurredOn) : IDomainEvent;