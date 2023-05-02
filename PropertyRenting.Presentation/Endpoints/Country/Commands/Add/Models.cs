namespace PropertyRenting.API.Endpoints.Country.Commands.Add;

internal record Request
{
    public string Name { get; init; }
    public string Nationality { get; init; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Nationality).NotEmpty();
    }
}