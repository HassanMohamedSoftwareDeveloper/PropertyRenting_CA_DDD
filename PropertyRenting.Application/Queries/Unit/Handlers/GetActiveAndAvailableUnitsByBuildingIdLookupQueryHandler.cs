using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Unit;

namespace PropertyRenting.Application.Queries.Unit.Handlers;

internal sealed class GetActiveAndAvailableUnitsByBuildingIdLookupQueryHandler : IRequestHandler<GetActiveAndAvailableUnitsByBuildingIdLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IUnitReadRepository _unitReadRepository;

    public GetActiveAndAvailableUnitsByBuildingIdLookupQueryHandler(IUnitReadRepository unitReadRepository)
    {
        _unitReadRepository = unitReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetActiveAndAvailableUnitsByBuildingIdLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitReadRepository.GetLookupAsync<BaseLookupDTO>(new GetActiveAndAvailableUnitsByBuildingIdLookupSpecification(request.BuildingId),
            cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
