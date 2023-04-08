namespace PropertyRenting.Domain.Errors;

public static partial class Errors
{

    public static class Renter
    {
        public static Error EmptyName => Error.Validation(code: "Renter.EmptyName", description: "Renter name can't be empty.");
        public static Error InvalidRenterType => Error.Validation(code: "Renter.InvalidRenterType", description: "Invalid Renter Type.");
        public static Error InvalidGender => Error.Validation(code: "Renter.InvalidGender", description: "Invalid Gender.");

        public static class ContactPerson
        {
            public static Error EmptyName => Error.Validation(code: "ContactPerson.EmptyName", description: "Contact person name can't be empty.");
        }
    }
}