namespace PropertyRenting.Domain.ValueObjects.Building;

public class UnitName : ValueObject
{
    public string Value { get; }
    private UnitName(string value) => Value = value;
    public static ErrorOr<UnitName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Building.Unit.EmptyUnitName;

        return new UnitName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
