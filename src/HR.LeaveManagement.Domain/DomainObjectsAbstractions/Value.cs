namespace HR.LeaveManagement.Domain.DomainObjectsAbstractions;

public abstract class Value<T> where T : Value<T>
{
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        var other = obj as T;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public static bool operator ==(Value<T>? left, Value<T>? right) => Equals(left, right);

    public static bool operator !=(Value<T>? left, Value<T>? right) => !Equals(left, right);
}
