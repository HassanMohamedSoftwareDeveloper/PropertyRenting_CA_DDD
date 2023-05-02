using Mapster;
using PropertyRenting.API.Endpoints.District;
using PropertyRenting.Application.Commands.District;

namespace PropertyRenting.API.Endpoints.District.Commands.Update;

internal sealed class UpdateEndpoint : Endpoint<Request>
{
    private readonly ISender _sender;

    public UpdateEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("update/{DistrictId}");
        AllowAnonymous();
        Group<DistrictGroup>();
        Description(x => x.WithName("UpdateDistrict")
        .Produces(204)
        .Produces<ErrorResponse>(409)
        .ProducesValidationProblem()
        .ProducesProblemFE<InternalErrorResponse>(500)
        );

        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.Adapt<UpdateDistrictCommand>(), cancellationToken);
        if (result.IsError == false)
            await SendNoContentAsync(cancellationToken);
    }
}
