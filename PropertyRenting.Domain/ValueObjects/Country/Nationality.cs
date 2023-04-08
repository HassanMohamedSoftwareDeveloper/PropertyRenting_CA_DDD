using ErrorOr;

namespace PropertyRenting.Domain.ValueObjects.Country;

public class Nationality : ValueObject
{
    public string Value { get; }
    private Nationality(string value) => Value = value;
    public static ErrorOr<Nationality> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Country.EmptyNationality;

        return new Nationality(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
