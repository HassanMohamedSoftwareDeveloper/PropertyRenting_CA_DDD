namespace PropertyRenting.Domain.ValueObjects.Common;

public class Percentage : ValueObject
{
    public decimal Value { get; }
    private Percentage(decimal value) => Value = value;
    public static ErrorOr<Percentage> Create(decimal value)
    {
        if (value <= 0 || value > 100)
            return Errors.Errors.Common.InvalidPercentage;

        return new Percentage(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
