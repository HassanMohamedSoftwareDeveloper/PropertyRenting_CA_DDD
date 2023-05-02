using PropertyRenting.Application.Commands.City;

namespace PropertyRenting.API.Endpoints.City.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{CountryId}/{CityId}");
        AllowAnonymous();
        Group<CityGroup>();
        Description(x => x.WithName("RemoveCity")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var countryId = Route<Guid>("CountryId", isRequired: true);
        var cityId = Route<Guid>("CityId", isRequired: true);
        var result = await _sender.Send(new DeleteCityCommand(countryId, cityId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
