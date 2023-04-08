using PropertyRenting.Application.Commands.District;

namespace PropertyRenting.Presentation.Endpoints.District.Commands.Delete;

internal sealed class DeleteEndpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public DeleteEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{CountryId}/{CityId}/{DistrictId}");
        AllowAnonymous();
        Group<DistrictGroup>();
        Description(x => x.WithName("RemoveDistrict")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var countryId = Route<Guid>("CountryId", isRequired: true);
        var cityId = Route<Guid>("CityId", isRequired: true);
        var DistrictId = Route<Guid>("DistrictId", isRequired: true);
        var result = await _sender.Send(new DeleteDistrictCommand(countryId, cityId, DistrictId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
