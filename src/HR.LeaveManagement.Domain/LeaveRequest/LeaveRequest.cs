using HR.LeaveManagement.Domain.DomainObjectsAbstractions;
using HR.LeaveManagement.Domain.LeaveRequest.Events;
using HR.LeaveManagement.Domain.LeaveRequest.ValueObjects;
using HR.LeaveManagement.Domain.ValueObjects;

namespace HR.LeaveManagement.Domain.LeaveRequest;

public class LeaveRequest : AggregateRoot<LeaveRequestId>
{
    public EmployeeId RequestingEmployeeId { get; private set; }
    public Guid LeaveTypeId { get; private set; }
    public DateRange DateRange { get; private set; }
    public LeaveRequestStatus Status { get; private set; } // ==> should be enum? or value object?
    public string Comments { get; private set; } 

    // TODO: add Request Attachments entities
    
    private LeaveRequest() { } 

    
    
    public static LeaveRequest Submit(Guid id, EmployeeId employeeId,
        Guid leaveTypeId, DateRange dateRange, string comments = "")
    {
        var request = new LeaveRequest();
        request.Apply(new LeaveRequested(id, employeeId, leaveTypeId,
            dateRange.Start, dateRange.End, DateTimeOffset.UtcNow));
        // comments aren't in LeaveRequested event in current definition, but we can set them if needed
        return request;
    }

    public void Approve(EmployeeId approverId)
    {
        if (Status != LeaveRequestStatus.Pending)
            throw new InvalidOperationException("Only pending requests can be approved.");
        if(Status == LeaveRequestStatus.Approved)
            throw new InvalidOperationException("Request is already approved.");
        
        Apply(new LeaveApproved(Id, approverId, DateTimeOffset.UtcNow));
    }

    public void Reject(EmployeeId approverId, string reason)
    {
        if (Status != LeaveRequestStatus.Pending)
            throw new InvalidOperationException("Only pending requests can be rejected.");
        
        Apply(new LeaveRejected(Id, approverId, reason, DateTimeOffset.UtcNow));
    }

    public void Cancel(EmployeeId requestingEmployeeId)
    {
        if (Status == LeaveRequestStatus.Cancelled)
            throw new InvalidOperationException("Request is already cancelled.");
        
        if (Status == LeaveRequestStatus.Approved)
            throw new InvalidOperationException("Approved requests cannot be cancelled directly.");
        
        Apply(new LeaveCancelled(Id, requestingEmployeeId, DateTimeOffset.UtcNow));
    }

    protected override void EnsureValidState()
    {
        var valid = Id != Guid.Empty &&
                     RequestingEmployeeId != null &&
                     LeaveTypeId != Guid.Empty &&
                     DateRange != null &&
                     Status != null;

        if (!valid)
            throw new InvalidOperationException("Post-checks failed in LeaveRequest aggregate.");
    }

    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case LeaveRequested e:
                Id = new LeaveRequestId(e.LeaveRequestId);
                RequestingEmployeeId = new EmployeeId(e.EmployeeId);
                LeaveTypeId = e.LeaveTypeId;
                DateRange = DateRange.Create(e.StartDate, e.EndDate);
                Status = LeaveRequestStatus.Pending;
                break;
            case LeaveApproved e:
                Status = LeaveRequestStatus.Approved;
                break;
            case LeaveRejected e:
                Status = LeaveRequestStatus.Rejected;
                break;
            case LeaveCancelled e:
                Status = LeaveRequestStatus.Cancelled;
                break;
        }
    }
}
