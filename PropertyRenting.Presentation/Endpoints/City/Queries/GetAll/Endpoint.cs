using PropertyRenting.API.Endpoints.City;
using PropertyRenting.Application.Queries.City;

namespace PropertyRenting.API.Endpoints.City.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<CityReadDTO>>
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
        Group<CityGroup>();
        Description(x => x.WithName("GetAllCities").Produces<List<CityReadDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllCitiesQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}

