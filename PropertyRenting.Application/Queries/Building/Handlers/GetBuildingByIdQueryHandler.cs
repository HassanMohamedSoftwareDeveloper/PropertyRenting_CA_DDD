using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Building;

namespace PropertyRenting.Application.Queries.Building.Handlers;

internal sealed class GetBuildingByIdQueryHandler : IRequestHandler<GetBuildingByIdQuery, ErrorOr<BuildingDTO>>
{
    private readonly IBuildingReadRepository _buildingReadRepository;

    public GetBuildingByIdQueryHandler(IBuildingReadRepository buildingReadRepository)
    {
        _buildingReadRepository = buildingReadRepository;
    }
    public async Task<ErrorOr<BuildingDTO>> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _buildingReadRepository.GetByIdAsync<BuildingDTO>(new GetBuildingByIdSpecification(request.BuildingId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}