namespace PropertyRenting.Domain.ValueObjects.Renter;

public class RenterName : ValueObject
{
    public string Value { get; }
    private RenterName(string value) => Value = value;
    public static ErrorOr<RenterName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Renter.EmptyName;

        return new RenterName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
