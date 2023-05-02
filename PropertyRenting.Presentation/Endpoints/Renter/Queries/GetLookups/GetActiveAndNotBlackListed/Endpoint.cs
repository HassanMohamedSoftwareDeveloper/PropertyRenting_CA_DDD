using PropertyRenting.Application.Queries.Renter;

namespace PropertyRenting.API.Endpoints.Renter.Queries.GetLookups.GetActiveAndNotBlackListed;

internal sealed class Endpoint : EndpointWithoutRequest<List<BaseLookupDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("lookups/get-active-and-not-black-listed");
        AllowAnonymous();
        Group<RenterGroup>();
        Description(x => x.WithName("GetActiveAndNotBlackListedRentersLookup").Produces<List<BaseLookupDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetActiveAndNotBlackListedRentersLookupQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNoContentAsync(cancellationToken);
    }
}
