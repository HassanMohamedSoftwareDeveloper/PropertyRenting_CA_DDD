namespace PropertyRenting.API.Endpoints.District.Commands.Add;

internal record Request
{
    public Guid CountryId { get; init; }
    public Guid CityId { get; init; }
    public string Name { get; init; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.CountryId).NotEmpty();
        RuleFor(x => x.CityId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}