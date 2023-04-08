namespace PropertyRenting.Application.Errors;

internal static class Queries
{
    public static Error NoData => Error.Custom(1, code: "NoData", description: "No data found.");
    public static Error NotFound => Error.NotFound("NotFound", description: "Not found.");
}