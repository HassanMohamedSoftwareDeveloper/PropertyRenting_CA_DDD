using Mapster;
using PropertyRenting.Application.Commands.Renter;

namespace PropertyRenting.Presentation.Endpoints.Renter.Commands.Add;

internal sealed class Endpoint : Endpoint<Request>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("create");
        AllowAnonymous();
        Group<RenterGroup>();
        Description(x => x.WithName("CreateRenter")
        .Produces(204)
        .Produces<ErrorResponse>(409)
        .ProducesValidationProblem()
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.Adapt<AddRenterCommand>(), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
