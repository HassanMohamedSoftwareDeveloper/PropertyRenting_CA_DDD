namespace PropertyRenting.Presentation.Endpoints.District.Commands.Update;

internal record Request
{
    [BindFrom("DistrictId")]
    public Guid Id { get; init; }
    public Guid CountryId { get; init; }
    public Guid CityId { get; init; }
    public string Name { get; init; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.CountryId).NotEmpty();
        RuleFor(x => x.CityId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}