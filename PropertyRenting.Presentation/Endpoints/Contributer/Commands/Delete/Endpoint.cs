using PropertyRenting.API.Endpoints.Contributer;
using PropertyRenting.Application.Commands.Contributer;

namespace PropertyRenting.API.Endpoints.Contributer.Commands.Delete;

internal sealed class Endpoint : EndpointWithoutRequest
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("remove/{ContributerId}");
        AllowAnonymous();
        Group<ContributerGroup>();
        Description(x => x.WithName("RemoveContributer")
        .Produces(204)
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var ContributerId = Route<Guid>("ContributerId", isRequired: true);
        var result = await _sender.Send(new DeleteContributerCommand(ContributerId), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
