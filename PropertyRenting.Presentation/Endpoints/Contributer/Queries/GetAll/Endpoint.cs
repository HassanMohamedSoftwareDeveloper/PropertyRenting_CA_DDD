using PropertyRenting.Application.Queries.Contributer;

namespace PropertyRenting.Presentation.Endpoints.Contributer.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<ContributerDTO>>
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
        Group<ContributerGroup>();
        Description(x => x.WithName("GetAllContributers").Produces<List<ContributerDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllContributersQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
