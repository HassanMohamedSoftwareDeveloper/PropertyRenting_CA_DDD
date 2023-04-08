namespace PropertyRenting.Presentation.Endpoints.Employee.Commands.Update;

internal record Request
{
    [BindFrom("EmployeeId")]
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string MobileNumber { get; init; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.MobileNumber).NotEmpty();
    }
}