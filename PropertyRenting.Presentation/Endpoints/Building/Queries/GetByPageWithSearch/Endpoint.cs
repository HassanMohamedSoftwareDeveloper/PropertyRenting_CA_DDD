namespace PropertyRenting.Presentation.Endpoints.Building.Queries.GetByPageWithSearch;

internal sealed class Endpoint : Endpoint<Request, PagedList<BuildingReadDTO>>
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
        Group<BuildingGroup>();
        Description(x => x.WithName("GetBuildingsByPageWithSearch").Produces<PagedList<BuildingReadDTO>>(200).ProducesValidationProblem()
        .Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetBuildingsByPageWithSearchQuery(request.Search, request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
