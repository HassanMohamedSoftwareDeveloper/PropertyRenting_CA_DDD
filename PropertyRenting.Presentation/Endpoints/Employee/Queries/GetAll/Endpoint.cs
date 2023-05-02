﻿using PropertyRenting.API.Endpoints.Employee;
using PropertyRenting.Application.Queries.Employee;

namespace PropertyRenting.API.Endpoints.Employee.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<EmployeeDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("get-all");
        AllowAnonymous();
        Group<EmployeeGroup>();
        Description(x => x.WithName("GetAllEmployees").Produces<List<EmployeeDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllEmployeesQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
