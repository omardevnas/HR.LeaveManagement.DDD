using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveRequest.Events;

public record LeaveApproved(
    Guid LeaveRequestId,
    Guid ApproverId,
    DateTimeOffset OccurredOn) : IDomainEvent;