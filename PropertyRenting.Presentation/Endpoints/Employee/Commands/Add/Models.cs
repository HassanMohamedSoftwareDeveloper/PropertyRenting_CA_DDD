namespace PropertyRenting.API.Endpoints.Employee.Commands.Add;

internal record Request
{
    public string Name { get; init; }
    public string MobileNumber { get; init; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.MobileNumber).NotEmpty();
    }
}