using PropertyRenting.Application.Queries.City;

namespace PropertyRenting.Presentation.Endpoints.City.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<CityDTO>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("get-by-id/{id}");
        AllowAnonymous();
        Group<CityGroup>();
        Description(x => x.WithName("GetCityById").Produces<CityDTO>(200).Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var id = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetCityByIdQuery(id), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNotFoundAsync(cancellationToken);
    }
}
