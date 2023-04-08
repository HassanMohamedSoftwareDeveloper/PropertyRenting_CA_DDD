namespace PropertyRenting.Domain.ValueObjects.Common;

public class EntityId : ValueObject
{
    public Guid Value { get; }
    private EntityId(Guid value) => Value = value;
    public static ErrorOr<EntityId> Create(Guid value)
    {
        if (value == Guid.Empty)
            return Errors.Errors.Common.InvalidEntityId;

        return new EntityId(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}