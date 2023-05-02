using PropertyRenting.Application.Queries.Renter;

namespace PropertyRenting.API.Endpoints.Renter.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<RenterReadDTO>>
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
        Group<RenterGroup>();
        Description(x => x.WithName("GetAllRenters").Produces<List<RenterReadDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllRentersQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNoContentAsync(cancellationToken);
    }
}
