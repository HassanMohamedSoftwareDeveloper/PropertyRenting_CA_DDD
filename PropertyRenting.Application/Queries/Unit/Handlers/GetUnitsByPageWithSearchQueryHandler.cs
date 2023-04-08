using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Unit;

namespace PropertyRenting.Application.Queries.Unit.Handlers;

internal sealed class GetUnitsByPageWithSearchQueryHandler : IRequestHandler<GetUnitsByPageWithSearchQuery, ErrorOr<PagedList<UnitReadDTO>>>
{
    private readonly IUnitReadRepository _unitReadRepository;

    public GetUnitsByPageWithSearchQueryHandler(IUnitReadRepository unitReadRepository)
    {
        _unitReadRepository = unitReadRepository;
    }
    public async Task<ErrorOr<PagedList<UnitReadDTO>>> Handle(GetUnitsByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitReadRepository.GetPageAsync<UnitReadDTO>(new GetUnitsByPageWithSearchSpecification(request.SearchValue),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
