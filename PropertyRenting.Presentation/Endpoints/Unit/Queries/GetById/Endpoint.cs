using PropertyRenting.Application.Queries.Unit;

namespace PropertyRenting.Presentation.Endpoints.Unit.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<UnitDTO>
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
        Group<UnitGroup>();
        Description(x => x.WithName("GetUnitById").Produces<UnitDTO>(200).ProducesValidationProblem().Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var UnitId = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetUnitByIdQuery(UnitId), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNotFoundAsync(cancellationToken);
    }
}

