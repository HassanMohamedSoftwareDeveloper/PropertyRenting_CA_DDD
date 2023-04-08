using Mapster;

namespace PropertyRenting.Presentation.Endpoints.Country.Commands.Update;

internal sealed class Endpoint : Endpoint<Request>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("update/{CountryId}");
        AllowAnonymous();
        Group<CountryGroup>();
        Description(x => x.WithName("UpdateCountry")
        .Produces(204)
        .Produces<ErrorResponse>(409)
        .ProducesValidationProblem()
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.Adapt<UpdateCountryCommand>(), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}