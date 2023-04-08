namespace PropertyRenting.Domain.ValueObjects.Country;

public class CityName : ValueObject
{
    public string Value { get; }
    private CityName(string value) => Value = value;
    public static ErrorOr<CityName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Country.City.EmptyName;

        return new CityName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
