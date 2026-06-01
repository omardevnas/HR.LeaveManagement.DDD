using HR.LeaveManagement.Domain.DomainObjectsAbstractions;

namespace HR.LeaveManagement.Domain.LeaveRequest.Events;

public record LeaveRequested(
    Guid LeaveRequestId,
    Guid EmployeeId,
    Guid LeaveTypeId,
    DateTime StartDate,
    DateTime EndDate,
    DateTimeOffset OccurredOn) : IDomainEvent;