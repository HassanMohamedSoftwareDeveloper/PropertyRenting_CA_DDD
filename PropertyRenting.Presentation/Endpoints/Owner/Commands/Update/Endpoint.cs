using Mapster;
using PropertyRenting.API.Endpoints.Owner;
using PropertyRenting.Application.Commands.Owner;

namespace PropertyRenting.API.Endpoints.Owner.Commands.Update;

internal sealed class Endpoint : Endpoint<Request>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("update/{OwnerId}");
        AllowAnonymous();
        Group<OwnerGroup>();
        Description(x => x.WithName("UpdateOwner")
        .Produces(204)
        .Produces<ErrorResponse>(409)
        .ProducesValidationProblem()
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.Adapt<UpdateOwnerCommand>(), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}