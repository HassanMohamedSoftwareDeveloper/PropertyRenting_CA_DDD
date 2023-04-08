using System.Text.RegularExpressions;

namespace PropertyRenting.Domain.ValueObjects.Common;

public class EmailAddress : ValueObject
{
    public string Value { get; }
    private EmailAddress(string value) => Value = value;
    public static ErrorOr<EmailAddress> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) is false)
        {
            Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(value);
            if (match.Success is false)
                return Errors.Errors.Common.InvalidEmail;
        }
        return new EmailAddress(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
