using PropertyRenting.Application.Commands.Building;

namespace PropertyRenting.Presentation.Endpoints.Building.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{BuildingId}");
        AllowAnonymous();
        Group<BuildingGroup>();
        Description(x => x.WithName("RemoveBuilding")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var BuildingId = Route<Guid>("BuildingId", isRequired: true);
        var result = await _sender.Send(new DeleteBuildingCommand(BuildingId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
