namespace PropertyRenting.Domain.ValueObjects.Building;

public class UnitNumber : ValueObject
{
    public string Value { get; }
    private UnitNumber(string value) => Value = value;
    public static ErrorOr<UnitNumber> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Building.Unit.EmptyUnitNumber;

        return new UnitNumber(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
