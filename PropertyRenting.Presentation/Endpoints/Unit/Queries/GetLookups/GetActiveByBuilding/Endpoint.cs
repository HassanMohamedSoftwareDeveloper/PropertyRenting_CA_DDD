using PropertyRenting.Application.Queries.Unit;

namespace PropertyRenting.Presentation.Endpoints.Unit.Queries.GetLookups.GetActiveByBuilding;

internal sealed class Endpoint : EndpointWithoutRequest<List<BaseLookupDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("lookups/get-active-by-building/{BuildingId}");
        AllowAnonymous();
        Group<UnitGroup>();
        Description(x => x.WithName("GetActiveUnitsByBuildingLookup").Produces<List<BaseLookupDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var buildingId = Route<Guid>("BuildingId", isRequired: true);
        var result = await _sender.Send(new GetActiveUnitsByBuildingIdLookupQuery(buildingId), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNoContentAsync(cancellationToken);
    }
}
