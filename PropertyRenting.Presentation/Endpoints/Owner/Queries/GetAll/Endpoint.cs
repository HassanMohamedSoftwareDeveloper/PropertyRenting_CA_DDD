using PropertyRenting.Application.Queries.Owner;

namespace PropertyRenting.Presentation.Endpoints.Owner.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<OwnerDTO>>
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
        Group<OwnerGroup>();
        Description(x => x.WithName("GetAllOwners").Produces<List<OwnerDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllOwnersQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
