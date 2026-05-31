using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Domain.Events;
using HR.LeaveManagement.Domain.ValueObjects;

namespace HR.LeaveManagement.Domain.Aggregates;

public class LeaveRequest : AggregateRoot<Guid>
{
    public EmployeeId RequestingEmployeeId { get; private set; } = null!;
    public Guid LeaveTypeId { get; private set; }
    public DateRange DateRange { get; private set; } = null!;
    public LeaveRequestStatus Status { get; private set; } = null!;
    public string Comments { get; private set; } = string.Empty;

    private LeaveRequest() { } // For EF Core

    public static LeaveRequest Submit(Guid id, EmployeeId employeeId,
        Guid leaveTypeId, DateRange dateRange, string comments = "")
    {
        var request = new LeaveRequest
        {
            Id = id,
            RequestingEmployeeId = employeeId,
            LeaveTypeId = leaveTypeId,
            DateRange = dateRange,
            Status = LeaveRequestStatus.Pending,
            Comments = comments
        };
        request.Raise(new LeaveRequested(id, employeeId.Value, leaveTypeId,
            dateRange.Start, dateRange.End, DateTimeOffset.UtcNow));
        return request;
    }

    public void Approve(string approverId)
    {
        if (Status != LeaveRequestStatus.Pending)
            throw new InvalidOperationException("Only pending requests can be approved.");
        
        Status = LeaveRequestStatus.Approved;
        Raise(new LeaveApproved(Id, approverId, DateTimeOffset.UtcNow));
    }

    public void Reject(string approverId, string reason)
    {
        if (Status != LeaveRequestStatus.Pending)
            throw new InvalidOperationException("Only pending requests can be rejected.");
        
        Status = LeaveRequestStatus.Rejected;
        Raise(new LeaveRejected(Id, approverId, reason, DateTimeOffset.UtcNow));
    }

    public void Cancel(string requestingEmployeeId)
    {
        if (Status == LeaveRequestStatus.Cancelled)
            throw new InvalidOperationException("Request is already cancelled.");
        
        if (Status == LeaveRequestStatus.Approved)
            throw new InvalidOperationException("Approved requests cannot be cancelled directly.");
        
        Status = LeaveRequestStatus.Cancelled;
        Raise(new LeaveCancelled(Id, requestingEmployeeId, DateTimeOffset.UtcNow));
    }
}
