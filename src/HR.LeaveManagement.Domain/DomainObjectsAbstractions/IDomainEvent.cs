namespace HR.LeaveManagement.Domain.DomainObjectsAbstractions;

public interface IDomainEvent
{
    DateTimeOffset OccurredOn { get; }
}
