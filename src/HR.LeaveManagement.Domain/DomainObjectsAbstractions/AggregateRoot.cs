namespace HR.LeaveManagement.Domain.DomainObjectsAbstractions;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    public TId Id { get; protected set; } = default!;
    private readonly List<object> _changes = new();

    public IEnumerable<object> GetChanges() => _changes.AsReadOnly();

    public void ClearChanges() => _changes.Clear();

    protected abstract void When(IDomainEvent @event);

    protected void Apply(IDomainEvent @event)
    {
        When(@event);
        EnsureValidState();
        _changes.Add(@event);
    }

    public void Load(IEnumerable<IDomainEvent> history)
    {
        foreach (var @event in history)
        {
            When(@event);
        }
    }

    protected abstract void EnsureValidState();
}
