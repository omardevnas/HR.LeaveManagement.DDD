using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveRequest.Events;

public record LeaveCancelled(
    Guid LeaveRequestId,
    Guid RequestingEmployeeId,
    DateTimeOffset OccurredOn) : IDomainEvent;