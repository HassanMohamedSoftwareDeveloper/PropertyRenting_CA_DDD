namespace PropertyRenting.Domain.ValueObjects.Employee;

public class EmployeeName : ValueObject
{
    public string Value { get; }
    private EmployeeName(string value) => Value = value;
    public static ErrorOr<EmployeeName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Employee.EmptyName;

        return new EmployeeName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
