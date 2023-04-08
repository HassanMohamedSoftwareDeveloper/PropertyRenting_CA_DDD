using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Building;

namespace PropertyRenting.Application.Queries.Building.Handlers;

internal sealed class GetBuildingsByPageWithSearchQueryHandler : IRequestHandler<GetBuildingsByPageWithSearchQuery, ErrorOr<PagedList<BuildingReadDTO>>>
{
    private readonly IBuildingReadRepository _buildingReadRepository;

    public GetBuildingsByPageWithSearchQueryHandler(IBuildingReadRepository buildingReadRepository)
    {
        _buildingReadRepository = buildingReadRepository;
    }
    public async Task<ErrorOr<PagedList<BuildingReadDTO>>> Handle(GetBuildingsByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _buildingReadRepository.GetPageAsync<BuildingReadDTO>(new GetBuildingsByPageWithSearchSpecification(request.SearchValue), request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
