namespace PropertyRenting.Presentation.Endpoints.Building.Queries.GetActiveBuildingsLookup;

internal sealed class Endpoint : EndpointWithoutRequest<List<BaseLookupDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("lookups/get-active");
        AllowAnonymous();
        Group<BuildingGroup>();
        Description(x => x.WithName("GetActiveBuildingsLookup").Produces<List<BaseLookupDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetActiveBuildingsLookupQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNoContentAsync(cancellationToken);
    }
}
