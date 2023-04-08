using PropertyRenting.Application.Queries.Owner;

namespace PropertyRenting.Presentation.Endpoints.Owner.Queries.GetLookup;

internal sealed class Endpoint : EndpointWithoutRequest<List<BaseLookupDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("lookups/get-all");
        AllowAnonymous();
        Group<OwnerGroup>();
        Description(x => x.WithName("GetOwnersLookup").Produces<List<BaseLookupDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetOwnersLookupQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
