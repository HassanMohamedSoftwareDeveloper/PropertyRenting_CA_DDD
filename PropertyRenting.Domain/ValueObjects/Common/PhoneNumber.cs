using System.Text.RegularExpressions;

namespace PropertyRenting.Domain.ValueObjects.Common;

public class PhoneNumber : ValueObject
{
    public string Value { get; }
    private PhoneNumber(string value) => Value = value;
    public static ErrorOr<PhoneNumber> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) is false)
        {
            Regex regex = new(@"^(\+[0-9]{9})$");
            Match match = regex.Match(value);
            if (match.Success is false)
                return Errors.Errors.Common.InvalidPhoneNumber;
        }

        return new PhoneNumber(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
