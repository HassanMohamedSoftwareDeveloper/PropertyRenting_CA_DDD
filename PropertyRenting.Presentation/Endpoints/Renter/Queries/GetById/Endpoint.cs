using PropertyRenting.Application.Queries.Renter;

namespace PropertyRenting.Presentation.Endpoints.Renter.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<RenterDTO>
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
        Group<RenterGroup>();
        Description(x => x.WithName("GetRenterById").Produces<RenterDTO>(200).ProducesValidationProblem().Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var RenterId = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetRenterByIdQuery(RenterId), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNotFoundAsync(cancellationToken);
    }
}

