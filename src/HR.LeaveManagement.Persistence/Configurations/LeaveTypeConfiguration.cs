using HR.LeaveManagement.Domain.LeaveType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name, n =>
        {
            n.Property(p => p.Value)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.OwnsOne(x => x.LeaveDays, d =>
        {
            d.Property(p => p.Value)
                .HasColumnName("DefaultDays")
                .IsRequired();
        });

        builder.Ignore(x => x.GetChanges());
    }
}
