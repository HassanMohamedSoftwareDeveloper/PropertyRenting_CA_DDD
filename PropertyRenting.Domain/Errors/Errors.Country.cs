namespace PropertyRenting.Domain.Errors
{
    public static partial class Errors
    {
        public static class Country
        {
            public static Error EmptyName => Error.Validation(code: "Country.EmptyName", description: "Country name can't be empty.");
            public static Error ExistCountry => Error.Conflict(code: "Country.Exist", description: "Country name or nationality exist before.");
            public static Error EmptyNationality => Error.Validation(code: "Country.EmptyNationality", description: "Nationality can't be empty.");


            public static class City
            {
                public static Error EmptyName => Error.Validation(code: "City.EmptyName", description: "City name can't be empty.");
                public static Error ExistName => Error.Validation(code: "City.ExistName", description: "City name exist before on the same country.");

                public static class District
                {
                    public static Error EmptyName => Error.Validation(code: "District.EmptyName", description: "District name can't be empty.");
                    public static Error ExistName => Error.Validation(code: "District.ExistName", description: "District name exist before on the same city.");
                }
            }
        }
    }
}
