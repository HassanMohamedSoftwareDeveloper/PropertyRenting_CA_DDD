using PropertyRenting.API.Endpoints.Employee;
using PropertyRenting.Application.Commands.Employee;

namespace PropertyRenting.API.Endpoints.Employee.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{EmployeeId}");
        AllowAnonymous();
        Group<EmployeeGroup>();
        Description(x => x.WithName("RemoveEmployee")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var EmployeeId = Route<Guid>("EmployeeId", isRequired: true);
        var result = await _sender.Send(new DeleteEmployeeCommand(EmployeeId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
