using Mapster;
using PropertyRenting.Application.Commands.District;

namespace PropertyRenting.Presentation.Endpoints.District.Commands.Add;

internal sealed class AddEndpoint : Endpoint<Request>
{
    private readonly ISender _sender;

    public AddEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("create");
        AllowAnonymous();
        Group<DistrictGroup>();
        Description(x => x.WithName("CreateDistrict")
        .Produces(204)
        .Produces<ErrorResponse>(409)
        .ProducesValidationProblem()
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.Adapt<AddDistrictCommand>(), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
