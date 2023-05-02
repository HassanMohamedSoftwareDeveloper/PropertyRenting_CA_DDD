﻿namespace PropertyRenting.API.Endpoints.Country.Queries.GetByPage;

internal sealed class Endpoint : Endpoint<Request, PagedList<CountryDTO>>
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
        Group<CountryGroup>();
        Description(x => x.WithName("GetCountriesByPage").Produces<PagedList<CountryDTO>>(200).ProducesValidationProblem()
        .Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCountriesByPageQuery(request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
