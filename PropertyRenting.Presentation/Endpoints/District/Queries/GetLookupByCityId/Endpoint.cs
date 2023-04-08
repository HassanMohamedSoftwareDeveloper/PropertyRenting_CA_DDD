using PropertyRenting.Application.Queries.District;

namespace PropertyRenting.Presentation.Endpoints.District.Queries.GetLookupByCityId;

internal sealed class Endpoint : EndpointWithoutRequest<List<BaseLookupDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("lookups/get-all/{CityId}");
        AllowAnonymous();
        Group<DistrictGroup>();
        Description(x => x.WithName("GetDistrictsLookupByCity").Produces<List<BaseLookupDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var cityId = Route<Guid>("CityId", isRequired: true);
        var result = await _sender.Send(new GetDistrictsLookupByCityIdQuery(cityId), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
