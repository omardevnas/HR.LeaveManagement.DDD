using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain.Events;

public record LeaveTypeCreated(
    Guid Id,
    string Name,
    int DefaultDays,
    DateTimeOffset OccurredOn) : IDomainEvent;

public record LeaveTypeUpdated(
    Guid Id,
    string Name,
    int DefaultDays,
    DateTimeOffset OccurredOn) : IDomainEvent;

public record LeaveRequested(
    Guid LeaveRequestId,
    string EmployeeId,
    Guid LeaveTypeId,
    DateTime StartDate,
    DateTime EndDate,
    DateTimeOffset OccurredOn) : IDomainEvent;

public record LeaveApproved(
    Guid LeaveRequestId,
    string ApproverId,
    DateTimeOffset OccurredOn) : IDomainEvent;

public record LeaveRejected(
    Guid LeaveRequestId,
    string ApproverId,
    string Reason,
    DateTimeOffset OccurredOn) : IDomainEvent;

public record LeaveCancelled(
    Guid LeaveRequestId,
    string RequestingEmployeeId,
    DateTimeOffset OccurredOn) : IDomainEvent;

public record LeaveAllocated(
    Guid AllocationId,
    Guid LeaveTypeId,
    string EmployeeId,
    int Days,
    int Year,
    DateTimeOffset OccurredOn) : IDomainEvent;

public record LeaveAllocationAdjusted(
    Guid AllocationId,
    int NewDays,
    DateTimeOffset OccurredOn) : IDomainEvent;
