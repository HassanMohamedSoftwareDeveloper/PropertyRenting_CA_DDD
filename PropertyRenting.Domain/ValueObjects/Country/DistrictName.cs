using ErrorOr;

namespace PropertyRenting.Domain.ValueObjects.Country;

public class DistrictName : ValueObject
{
    public string Value { get; }
    private DistrictName(string value) => Value = value;
    public static ErrorOr<DistrictName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Country.City.District.EmptyName;

        return new DistrictName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
