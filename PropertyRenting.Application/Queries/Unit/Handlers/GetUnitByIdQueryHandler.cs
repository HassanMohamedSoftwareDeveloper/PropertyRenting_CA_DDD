using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Unit;

namespace PropertyRenting.Application.Queries.Unit.Handlers;

internal sealed class GetUnitByIdQueryHandler : IRequestHandler<GetUnitByIdQuery, ErrorOr<UnitDTO>>
{
    private readonly IUnitReadRepository _unitReadRepository;

    public GetUnitByIdQueryHandler(IUnitReadRepository unitReadRepository)
    {
        _unitReadRepository = unitReadRepository;
    }
    public async Task<ErrorOr<UnitDTO>> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitReadRepository.GetByIdAsync<UnitDTO>(new GetUnitByIdSpecification(request.UnitId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
