using PropertyRenting.API.Endpoints.Owner;
using PropertyRenting.Application.Commands.Owner;

namespace PropertyRenting.API.Endpoints.Owner.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{OwnerId}");
        AllowAnonymous();
        Group<OwnerGroup>();
        Description(x => x.WithName("RemoveOwner")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var OwnerId = Route<Guid>("OwnerId", isRequired: true);
        var result = await _sender.Send(new DeleteOwnerCommand(OwnerId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
