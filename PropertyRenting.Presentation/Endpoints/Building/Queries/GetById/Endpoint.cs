namespace PropertyRenting.Presentation.Endpoints.Building.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<BuildingDTO>
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
        Group<BuildingGroup>();
        Description(x => x.WithName("GetBuildingById").Produces<BuildingDTO>(200).ProducesValidationProblem().Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var buildingId = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetBuildingByIdQuery(buildingId), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNotFoundAsync(cancellationToken);
    }
}
