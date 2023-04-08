namespace PropertyRenting.Domain.Errors
{
    public static partial class Errors
    {
        public static class Common
        {
            public static Error NotFoundEntity => Error.NotFound(code: "NotFoundEntity", description: "Entity not found.");
            public static Error InvalidEntityId => Error.Validation(code: "InvalidEntityId", description: "Entity Id can't empty.");
            public static Error InvalidIdentityType => Error.Validation(code: "InvalidIdentityType", description: "Invalid Identity Type.");
            public static Error InvalidIdentityNumber => Error.Validation(code: "InvalidIdentityNumber", description: "Invalid Identity Number.");
            public static Error InvalidIdentityIssuePlace => Error.Validation(code: "InvalidIdentityIssuePlace", description: "Identity Issue Place can't be empty.");
            public static Error InvalidIdentityExpiryDate => Error.Validation(code: "InvalidIdentityExpiryDate", description: $"Identity Expiry Date can't less than current date ({DateTime.Now:yyyy-MM--dd}).");
            public static Error InvalidEmail => Error.Validation(code: "InvalidEmail", description: "Email address is invalid.");
            public static Error InvalidPercentage => Error.Validation(code: "InvalidPercentage", description: "The percentage must be greater than zero and less than or equal (100).");
            public static Error InvalidMobileNumber => Error.Validation(code: "InvalidMobileNumber", description: "Mobile number is invalid.");
            public static Error InvalidPhoneNumber => Error.Validation(code: "InvalidPhoneNumber", description: "Phone number is invalid.");
            public static Error HasTransactions => Error.Conflict(code: "HasTransactions", description: "Entity can't be deleted cause of it has transactions.");
        }
    }
}
