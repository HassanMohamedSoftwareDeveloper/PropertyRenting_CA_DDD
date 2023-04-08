namespace PropertyRenting.Presentation.Endpoints.Country.Commands.Update;

internal record Request
{
    [BindFrom("CountryId")]
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Nationality { get; init; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Nationality).NotEmpty();
    }
}