﻿namespace PropertyRenting.API.Endpoints.Owner.Commands.Update;

internal record Request
{
    [BindFrom("ContributerId")]
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string MobileNumber { get; init; }
    public string Email { get; init; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.MobileNumber).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
    }
}