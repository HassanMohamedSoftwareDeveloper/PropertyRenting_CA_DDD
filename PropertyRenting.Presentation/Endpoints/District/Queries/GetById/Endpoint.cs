using PropertyRenting.Application.Queries.District;

namespace PropertyRenting.API.Endpoints.District.Queries.GetById;

internal sealed class Endpoint : EndpointWithoutRequest<DistrictDTO>
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
        Group<DistrictGroup>();
        Description(x => x.WithName("GetDistrictById").Produces<DistrictDTO>(200).Produces(404).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var id = Route<Guid>("id", isRequired: true);
        var result = await _sender.Send(new GetDistrictByIdQuery(id), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNotFoundAsync(cancellationToken);
    }
}
