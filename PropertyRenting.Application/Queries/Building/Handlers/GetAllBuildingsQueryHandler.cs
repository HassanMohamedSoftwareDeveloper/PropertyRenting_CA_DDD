using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Building;

namespace PropertyRenting.Application.Queries.Building.Handlers;

internal sealed class GetAllBuildingsQueryHandler : IRequestHandler<GetAllBuildingsQuery, ErrorOr<List<BuildingReadDTO>>>
{
    private readonly IBuildingReadRepository _buildingReadRepository;

    public GetAllBuildingsQueryHandler(IBuildingReadRepository buildingReadRepository)
    {
        _buildingReadRepository = buildingReadRepository;
    }
    public async Task<ErrorOr<List<BuildingReadDTO>>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
    {
        var data = await _buildingReadRepository.GetAsync<BuildingReadDTO>(new GetBuildingsSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
