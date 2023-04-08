namespace PropertyRenting.Domain.ValueObjects.Building;

public class BuildingSymbol : ValueObject
{
    public string Value { get; }
    private BuildingSymbol(string value) => Value = value;
    public static ErrorOr<BuildingSymbol> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Building.EmptySymbol;

        return new BuildingSymbol(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
