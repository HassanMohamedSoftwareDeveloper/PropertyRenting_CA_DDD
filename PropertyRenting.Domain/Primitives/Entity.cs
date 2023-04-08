using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity() { }
    protected Entity(EntityId id) => Id = id;

    public EntityId Id { get; private init; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public static bool operator ==(Entity first, Entity second)
    {
        return first is not null && second is not null && first.Equals(second);
    }
    public static bool operator !=(Entity first, Entity second)
    {
        return !(first == second);
    }

    public bool Equals(Entity other)
    {
        if (other is null)
            return false;

        if (other.GetType() != GetType())
            return false;

        return other.Id == Id;
    }
    public override bool Equals(object obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not Entity entity)
            return false;

        return entity.Id == Id;

    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
