using PropertyRenting.API.Endpoints.Country;

namespace PropertyRenting.API.Endpoints.Country.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{CountryId}");
        AllowAnonymous();
        Group<CountryGroup>();
        Description(x => x.WithName("RemoveCountry")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var countryId = Route<Guid>("CountryId", isRequired: true);
        var result = await _sender.Send(new DeleteCountryCommand(countryId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
