namespace HR.LeaveManagement.Domain.LeaveRequest.Repositories;

public interface ILeaveRequestRepository
{
    Task<Domain.LeaveRequest.LeaveRequest?> GetById(Guid id);
    Task Add(Domain.LeaveRequest.LeaveRequest leaveRequest);
    Task Update(Domain.LeaveRequest.LeaveRequest leaveRequest);
    Task<IReadOnlyList<Domain.LeaveRequest.LeaveRequest>> GetByEmployee(string employeeId);
}