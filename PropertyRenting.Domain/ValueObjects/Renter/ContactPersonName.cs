namespace PropertyRenting.Domain.ValueObjects.Renter;

public class ContactPersonName : ValueObject
{
    public string Value { get; }
    private ContactPersonName(string value) => Value = value;
    public static ErrorOr<ContactPersonName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Renter.ContactPerson.EmptyName;

        return new ContactPersonName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}