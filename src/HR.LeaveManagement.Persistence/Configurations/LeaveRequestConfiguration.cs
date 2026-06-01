using HR.LeaveManagement.Domain.LeaveRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.RequestingEmployeeId, e =>
        {
            e.Property(p => p.Value)
                .HasColumnName("RequestingEmployeeId")
                .IsRequired();
        });

        builder.Property(x => x.LeaveTypeId).IsRequired();

        builder.OwnsOne(x => x.DateRange, dr =>
        {
            dr.Property(p => p.Start).HasColumnName("StartDate").IsRequired();
            dr.Property(p => p.End).HasColumnName("EndDate").IsRequired();
        });

        builder.Property(x => x.Status).HasConversion<string>();

        builder.Property(x => x.Comments).HasMaxLength(500);

        builder.Ignore(x => x.GetChanges());
    }
}
