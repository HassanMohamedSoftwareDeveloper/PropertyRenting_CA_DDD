﻿using PropertyRenting.Application.Queries.Unit;

namespace PropertyRenting.Presentation.Endpoints.Unit.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<UnitReadDTO>>
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
        Group<UnitGroup>();
        Description(x => x.WithName("GetAllUnits").Produces<List<UnitReadDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllUnitsQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNoContentAsync(cancellationToken);
    }
}