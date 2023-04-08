namespace PropertyRenting.Domain.ValueObjects.Building;

public class BuildingName : ValueObject
{
    public string Value { get; }
    private BuildingName(string value) => Value = value;
    public static ErrorOr<BuildingName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Building.EmptyName;

        return new BuildingName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
