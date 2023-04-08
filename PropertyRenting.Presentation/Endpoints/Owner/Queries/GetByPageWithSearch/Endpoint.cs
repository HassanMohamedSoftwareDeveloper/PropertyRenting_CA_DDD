using PropertyRenting.Application.Queries.Owner;

namespace PropertyRenting.Presentation.Endpoints.Owner.Queries.GetByPageWithSearch;

internal sealed class Endpoint : Endpoint<Request, PagedList<OwnerDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("get-by-page-with-search");
        AllowAnonymous();
        Group<OwnerGroup>();
        Description(x => x.WithName("GetOwnersByPageWithSearch").Produces<PagedList<OwnerDTO>>(200).ProducesValidationProblem()
        .Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetOwnersByPageWithSearchQuery(request.Search, request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}