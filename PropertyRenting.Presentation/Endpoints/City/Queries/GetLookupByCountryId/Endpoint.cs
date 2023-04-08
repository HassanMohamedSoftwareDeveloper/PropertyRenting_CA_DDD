using PropertyRenting.Application.Queries.City;

namespace PropertyRenting.Presentation.Endpoints.City.Queries.GetLookupByCountryId;

internal sealed class Endpoint : EndpointWithoutRequest<List<BaseLookupDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("lookups/get-all/{CountryId}");
        AllowAnonymous();
        Group<CityGroup>();
        Description(x => x.WithName("GetCitiesLookupByCountry").Produces<List<BaseLookupDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var countryId = Route<Guid>("CountryId", isRequired: true);
        var result = await _sender.Send(new GetCitiesLookupByCountryIdQuery(countryId), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
