using PropertyRenting.Application.Queries.Contributer;

namespace PropertyRenting.Presentation.Endpoints.Contributer.Queries.GetByPageWithSearch;

internal sealed class Endpoint : Endpoint<Request, PagedList<ContributerDTO>>
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
        Group<ContributerGroup>();
        Description(x => x.WithName("GetContributersByPageWithSearch").Produces<PagedList<ContributerDTO>>(200).ProducesValidationProblem()
        .Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetContributersByPageWithSearchQuery(request.Search, request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}