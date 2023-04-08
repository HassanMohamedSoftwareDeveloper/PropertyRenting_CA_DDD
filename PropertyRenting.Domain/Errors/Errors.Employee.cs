namespace PropertyRenting.Domain.Errors;

public static partial class Errors
{
    public static class Employee
    {
        public static Error EmptyName => Error.Validation(code: "Employee.EmptyName", description: "Employee name can't be empty.");
    }
}
