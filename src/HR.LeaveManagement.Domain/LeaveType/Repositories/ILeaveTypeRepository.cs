namespace HR.LeaveManagement.Domain.LeaveType.Repositories;

public interface ILeaveTypeRepository
{
    Task<Domain.LeaveType.LeaveType?> GetById(Guid id);
    Task Add(Domain.LeaveType.LeaveType leaveType);
    Task Update(Domain.LeaveType.LeaveType leaveType);
    Task Delete(Domain.LeaveType.LeaveType leaveType);
    Task<IReadOnlyList<Domain.LeaveType.LeaveType>> GetAll();
}