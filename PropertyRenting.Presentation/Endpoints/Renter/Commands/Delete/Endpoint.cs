using PropertyRenting.Application.Commands.Renter;

namespace PropertyRenting.Presentation.Endpoints.Renter.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{RenterId}");
        AllowAnonymous();
        Group<RenterGroup>();
        Description(x => x.WithName("RemoveRenter")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var RenterId = Route<Guid>("RenterId", isRequired: true);
        var result = await _sender.Send(new DeleteRenterCommand(RenterId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
