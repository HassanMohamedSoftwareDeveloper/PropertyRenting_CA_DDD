using PropertyRenting.Application.Queries.City;

namespace PropertyRenting.Presentation.Endpoints.City.Queries.GetByPageWithSearch;

internal sealed class Endpoint : Endpoint<Request, PagedList<CityReadDTO>>
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
        Group<CityGroup>();
        Description(x => x.WithName("GetCitiesByPageWithSearch").Produces<PagedList<CountryDTO>>(200)
        .Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {

        var result = await _sender.Send(new GetCitiesByPageWithSearchQuery(request.Search, request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
