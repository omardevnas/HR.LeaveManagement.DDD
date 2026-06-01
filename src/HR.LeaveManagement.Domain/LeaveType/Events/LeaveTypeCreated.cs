using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveType.Events;

public record LeaveTypeCreated(
    Guid Id,
    string Name,
    int DefaultDays,
    DateTimeOffset OccurredOn) : IDomainEvent;