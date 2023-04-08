namespace PropertyRenting.Domain.ValueObjects.Contributer;

public class ContributerName : ValueObject
{
    public string Value { get; }
    private ContributerName(string value) => Value = value;
    public static ErrorOr<ContributerName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Contributer.EmptyName;

        return new ContributerName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}