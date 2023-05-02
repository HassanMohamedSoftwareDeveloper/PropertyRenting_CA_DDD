using Mapster;
using PropertyRenting.API.Endpoints.Employee;
using PropertyRenting.Application.Commands.Employee;

namespace PropertyRenting.API.Endpoints.Employee.Commands.Update;

internal sealed class Endpoint : Endpoint<Request>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("update/{EmployeeId}");
        AllowAnonymous();
        Group<EmployeeGroup>();
        Description(x => x.WithName("UpdateEmployee")
        .Produces(204)
        .Produces<ErrorResponse>(409)
        .ProducesValidationProblem()
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.Adapt<UpdateEmployeeCommand>(), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}