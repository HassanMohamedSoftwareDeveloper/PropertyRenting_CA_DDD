using PropertyRenting.Application.Queries.Owner;

namespace PropertyRenting.Presentation.Endpoints.Owner.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<OwnerDTO>
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
        Group<OwnerGroup>();
        Description(x => x.WithName("GetOwnerById").Produces<OwnerDTO>(200).ProducesValidationProblem().Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var id = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetOwnerByIdQuery(id), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNotFoundAsync(cancellationToken);
    }
}
