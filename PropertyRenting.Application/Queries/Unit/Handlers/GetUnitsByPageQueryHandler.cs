using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Unit;

namespace PropertyRenting.Application.Queries.Unit.Handlers;

internal sealed class GetUnitsByPageQueryHandler : IRequestHandler<GetUnitsByPageQuery, ErrorOr<PagedList<UnitReadDTO>>>
{
    private readonly IUnitReadRepository _unitReadRepository;

    public GetUnitsByPageQueryHandler(IUnitReadRepository unitReadRepository)
    {
        _unitReadRepository = unitReadRepository;
    }
    public async Task<ErrorOr<PagedList<UnitReadDTO>>> Handle(GetUnitsByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitReadRepository.GetPageAsync<UnitReadDTO>(new GetUnitsByPageSpecification(),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
