using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Building;

namespace PropertyRenting.Application.Queries.Building.Handlers;

internal sealed class GetBuildingsByPageQueryHandler : IRequestHandler<GetBuildingsByPageQuery, ErrorOr<PagedList<BuildingReadDTO>>>
{
    private readonly IBuildingReadRepository _buildingReadRepository;

    public GetBuildingsByPageQueryHandler(IBuildingReadRepository buildingReadRepository)
    {
        _buildingReadRepository = buildingReadRepository;
    }
    public async Task<ErrorOr<PagedList<BuildingReadDTO>>> Handle(GetBuildingsByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _buildingReadRepository.GetPageAsync<BuildingReadDTO>(new GetBuildingsByPageSpecification(), request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
