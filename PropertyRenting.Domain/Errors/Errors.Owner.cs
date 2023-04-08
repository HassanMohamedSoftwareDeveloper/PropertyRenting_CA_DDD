namespace PropertyRenting.Domain.Errors;

public static partial class Errors
{
    public static class Owner
    {
        public static Error EmptyName => Error.Validation(code: "Owner.EmptyName", description: "Owner name can't be empty.");
    }
}
