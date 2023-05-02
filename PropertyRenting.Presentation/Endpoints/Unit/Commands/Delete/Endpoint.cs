using PropertyRenting.API.Endpoints.Unit;
using PropertyRenting.Application.Commands.Unit;

namespace PropertyRenting.API.Endpoints.Unit.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{BuildingId}/{UnitId}");
        AllowAnonymous();
        Group<UnitGroup>();
        Description(x => x.WithName("RemoveUnit")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var BuildingId = Route<Guid>("BuildingId", isRequired: true);
        var UnitId = Route<Guid>("UnitId", isRequired: true);
        var result = await _sender.Send(new DeleteUnitCommand(BuildingId, UnitId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
