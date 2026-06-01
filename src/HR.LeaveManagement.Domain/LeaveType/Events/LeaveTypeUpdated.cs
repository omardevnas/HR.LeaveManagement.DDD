using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveType.Events;

public record LeaveTypeUpdated(
    Guid Id,
    string Name,
    int DefaultDays,
    DateTimeOffset OccurredOn) : IDomainEvent;