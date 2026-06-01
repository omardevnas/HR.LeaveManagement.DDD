namespace HR.LeaveManagement.Domain.DomainObjectsAbstractions;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; } = default!;

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return Id!.Equals(other.Id);
    }

    public override int GetHashCode() => Id!.GetHashCode();

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b) => Equals(a, b);

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !Equals(a, b);
}
