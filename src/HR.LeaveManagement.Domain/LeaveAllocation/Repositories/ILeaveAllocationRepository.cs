namespace HR.LeaveManagement.Domain.LeaveAllocation.Repositories;

public interface ILeaveAllocationRepository
{
    Task<Domain.LeaveAllocation.LeaveAllocation?> GetById(Guid id);
    Task Add(Domain.LeaveAllocation.LeaveAllocation allocation);
    Task Update(Domain.LeaveAllocation.LeaveAllocation allocation);
    Task<Domain.LeaveAllocation.LeaveAllocation?> GetByEmployeeAndType(string employeeId, Guid leaveTypeId);
}