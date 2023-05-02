using PropertyRenting.Application.Queries.City;

namespace PropertyRenting.API.Endpoints.City.Queries.GetByPage;

internal sealed class Endpoint : Endpoint<Request, PagedList<CityReadDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("get-by-page");
        AllowAnonymous();
        Group<CityGroup>();
        Description(x => x.WithName("GetCitiesByPage").Produces<PagedList<CountryDTO>>(200)
        .Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);

        Summary(s =>
        {
            s.Params["Page"] = "Page number.";
            s.Params["PageSize"] = "Page size.";
        });
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCitiesByPageQuery(request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
