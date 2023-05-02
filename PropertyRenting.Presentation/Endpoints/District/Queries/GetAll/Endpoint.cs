using PropertyRenting.API.Endpoints.District;
using PropertyRenting.Application.Queries.District;

namespace PropertyRenting.API.Endpoints.District.Queries.GetAll;

internal sealed class Endpoint : EndpointWithoutRequest<List<DistrictReadDTO>>
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
        Group<DistrictGroup>();
        Description(x => x.WithName("GetAllDistricts").Produces<List<DistrictReadDTO>>(200).Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllDistrictsQuery(), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}

