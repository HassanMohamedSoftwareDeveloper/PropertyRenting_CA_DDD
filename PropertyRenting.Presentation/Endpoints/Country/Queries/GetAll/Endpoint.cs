namespace PropertyRenting.Presentation.Endpoints.Country.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<CountryDTO>>
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
        Group<CountryGroup>();
        Description(x => x.WithName("GetAllCountries").Produces<List<CountryDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllCountriesQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
