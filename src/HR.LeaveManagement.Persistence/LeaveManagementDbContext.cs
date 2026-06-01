using HR.LeaveManagement.Domain.LeaveAllocation;
using HR.LeaveManagement.Domain.LeaveRequest;
using HR.LeaveManagement.Domain.LeaveType;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence;

public class LeaveManagementDbContext : DbContext
{
    public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();
    public DbSet<LeaveAllocation> LeaveAllocations => Set<LeaveAllocation>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
