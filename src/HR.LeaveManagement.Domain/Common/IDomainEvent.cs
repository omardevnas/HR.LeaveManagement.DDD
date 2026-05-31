namespace HR.LeaveManagement.Domain.Common;

public interface IDomainEvent
{
    DateTimeOffset OccurredOn { get; }
}
