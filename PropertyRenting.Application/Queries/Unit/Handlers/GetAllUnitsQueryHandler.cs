using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Unit;

namespace PropertyRenting.Application.Queries.Unit.Handlers;

internal sealed class GetAllUnitsQueryHandler : IRequestHandler<GetAllUnitsQuery, ErrorOr<List<UnitReadDTO>>>
{
    private readonly IUnitReadRepository _unitReadRepository;

    public GetAllUnitsQueryHandler(IUnitReadRepository unitReadRepository)
    {
        _unitReadRepository = unitReadRepository;
    }
    public async Task<ErrorOr<List<UnitReadDTO>>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitReadRepository.GetAsync<UnitReadDTO>(new GetUnitsSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
