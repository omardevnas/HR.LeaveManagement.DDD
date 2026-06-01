using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveAllocation.Events;

public record LeaveAllocationAdjusted(
    Guid AllocationId,
    int NewDays,
    DateTimeOffset OccurredOn) : IDomainEvent;