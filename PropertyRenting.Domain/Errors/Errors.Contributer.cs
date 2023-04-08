namespace PropertyRenting.Domain.Errors;

public static partial class Errors
{
    public static class Contributer
    {
        public static Error EmptyName => Error.Validation(code: "Contributer.EmptyName", description: "Contributer name can't be empty.");
    }
}
