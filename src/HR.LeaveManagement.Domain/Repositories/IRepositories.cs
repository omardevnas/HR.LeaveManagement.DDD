using HR.LeaveManagement.Domain.Aggregates;

namespace HR.LeaveManagement.Domain.Repositories;

public interface ILeaveTypeRepository
{
    Task<LeaveType?> GetById(Guid id);
    Task Add(LeaveType leaveType);
    Task Update(LeaveType leaveType);
    Task Delete(LeaveType leaveType);
    Task<IReadOnlyList<LeaveType>> GetAll();
}

public interface ILeaveAllocationRepository
{
    Task<LeaveAllocation?> GetById(Guid id);
    Task Add(LeaveAllocation allocation);
    Task Update(LeaveAllocation allocation);
    Task<LeaveAllocation?> GetByEmployeeAndType(string employeeId, Guid leaveTypeId);
}

public interface ILeaveRequestRepository
{
    Task<LeaveRequest?> GetById(Guid id);
    Task Add(LeaveRequest leaveRequest);
    Task Update(LeaveRequest leaveRequest);
    Task<IReadOnlyList<LeaveRequest>> GetByEmployee(string employeeId);
}
