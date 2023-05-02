using PropertyRenting.API.Endpoints.Employee;
using PropertyRenting.Application.Queries.Employee;

namespace PropertyRenting.API.Endpoints.Employee.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<EmployeeDTO>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("get-by-id/{id}");
        AllowAnonymous();
        Group<EmployeeGroup>();
        Description(x => x.WithName("GetEmployeeById").Produces<EmployeeDTO>(200).ProducesValidationProblem().Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var id = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetEmployeeByIdQuery(id), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNotFoundAsync(cancellationToken);
    }
}
