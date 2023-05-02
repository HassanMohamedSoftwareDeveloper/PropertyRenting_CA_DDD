using PropertyRenting.API.Endpoints.Contributer;
using PropertyRenting.Application.Queries.Contributer;

namespace PropertyRenting.API.Endpoints.Contributer.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<ContributerDTO>
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
        Group<ContributerGroup>();
        Description(x => x.WithName("GetContributerById").Produces<ContributerDTO>(200).ProducesValidationProblem().Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var id = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetContributerByIdQuery(id), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);

        else
            await SendNotFoundAsync(cancellationToken);
    }
}
