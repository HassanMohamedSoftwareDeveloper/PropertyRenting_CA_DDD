using PropertyRenting.Application.Queries.Unit;

namespace PropertyRenting.Presentation.Endpoints.Unit.Queries.GetByPage;

internal sealed class Endpoint : Endpoint<Request, PagedList<UnitReadDTO>>
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("get-by-page");
        AllowAnonymous();
        Group<UnitGroup>();
        Description(x => x.WithName("GetUnitsByPage").Produces<PagedList<UnitReadDTO>>(200).ProducesValidationProblem()
        .Produces(204).ProducesProblemFE<InternalErrorResponse>(500));
        Version(1);
    }
    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetUnitsByPageQuery(request.Page, request.PageSize), cancellationToken);
        if (result.IsError is false)
            await SendAsync(result.Value, cancellation: cancellationToken);
        else
            await SendNoContentAsync(cancellationToken);
    }
}
