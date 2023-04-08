using Mapster;
using PropertyRenting.Application.Commands.Contributer;

namespace PropertyRenting.Presentation.Endpoints.Contributer.Commands.Update;

internal sealed class Endpoint : Endpoint<Request>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("update/{ContributerId}");
        AllowAnonymous();
        Group<ContributerGroup>();
        Description(x => x.WithName("UpdateContributer")
        .Produces(204)
        .Produces<ErrorResponse>(409)
        .ProducesValidationProblem()
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.Adapt<UpdateContributerCommand>(), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}