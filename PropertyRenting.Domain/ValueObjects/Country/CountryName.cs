using ErrorOr;

namespace PropertyRenting.Domain.ValueObjects.Country;

public class CountryName : ValueObject
{
    public string Value { get; }
    private CountryName(string value) => Value = value;
    public static ErrorOr<CountryName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Country.EmptyName;

        return new CountryName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
