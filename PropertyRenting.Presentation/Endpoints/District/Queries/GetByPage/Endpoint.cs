using PropertyRenting.Application.Queries.District;

namespace PropertyRenting.Presentation.Endpoints.District.Queries.GetByPage;

internal sealed class Endpoint : Endpoint<Request, PagedList<DistrictReadDTO>>
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
        Group<DistrictGroup>();
        Description(x => x.WithName("GetDistrictsByPage").Produces<PagedList<CountryDTO>>(200)
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
        var result = await _sender.Send(new GetDistrictsByPageQuery(request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
