namespace PropertyRenting.Domain.Errors;

public static partial class Errors
{

    public static class Building
    {
        public static Error EmptySymbol => Error.Validation(code: "Building.EmptySymbol", description: "Building symbol can't be empty.");
        public static Error ExistSymbol => Error.Validation(code: "Building.ExistSymbol", description: "Building symbol exist before.");
        public static Error EmptyName => Error.Validation(code: "Building.EmptyName", description: "Building name can't be empty.");
        public static Error InvalidPercentage => Error.Validation(code: "Building.InvalidPercentage", description: "Total Percentage for contributers must be less than or equal (100).");
        public static Error InvalidBuildingType => Error.Validation(code: "Building.InvalidBuildingType", description: "Building Type is invalid.");
        public static Error InvalidConstructionStatus => Error.Validation(code: "Building.InvalidConstructionStatus", description: "Building Construction Status is invalid.");

        public static class Unit
        {
            public static Error EmptyUnitNumber => Error.Validation(code: "Unit.EmptyUnitNumber", description: "Unit number can't be empty.");
            public static Error ExistUnitNumber => Error.Validation(code: "Unit.ExistUnitNumber", description: "Unit number exist before.");
            public static Error EmptyUnitName => Error.Validation(code: "Unit.EmptyUnitName", description: "Unit name can't be empty.");
        }
    }
}