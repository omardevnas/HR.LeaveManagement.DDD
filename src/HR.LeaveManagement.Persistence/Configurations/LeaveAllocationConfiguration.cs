using HR.LeaveManagement.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
{
    public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.LeaveTypeId).IsRequired();

        builder.OwnsOne(x => x.EmployeeId, e =>
        {
            e.Property(p => p.Value)
                .HasColumnName("EmployeeId")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Period, p =>
        {
            p.Property(pp => pp.Year)
                .HasColumnName("Period")
                .IsRequired();
        });

        builder.Property(x => x.NumberOfDays).IsRequired();

        builder.Ignore(b => b.DomainEvents);
    }
}
