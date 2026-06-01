using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveRequest.Events;

public record LeaveRejected(
    Guid LeaveRequestId,
    Guid ApproverId,
    string Reason,
    DateTimeOffset OccurredOn) : IDomainEvent;