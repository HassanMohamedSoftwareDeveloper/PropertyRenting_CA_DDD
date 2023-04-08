using System.Text.RegularExpressions;

namespace PropertyRenting.Domain.ValueObjects.Common;

public class MobileNumber : ValueObject
{
    public string Value { get; }
    private MobileNumber(string value) => Value = value;
    public static ErrorOr<MobileNumber> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) is false)
        {
            Regex regex = new(@"^(\+[0-9]{9})$");
            Match match = regex.Match(value);
            if (match.Success is false)
                return Errors.Errors.Common.InvalidMobileNumber;
        }

        return new MobileNumber(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
