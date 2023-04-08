using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Building;

namespace PropertyRenting.Application.Queries.Building.Handlers;

internal sealed class GetBuildingsLookupQueryHandler : IRequestHandler<GetBuildingsLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IBuildingReadRepository _buildingReadRepository;

    public GetBuildingsLookupQueryHandler(IBuildingReadRepository buildingReadRepository)
    {
        _buildingReadRepository = buildingReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetBuildingsLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _buildingReadRepository.GetAsync<BaseLookupDTO>(new GetBuildingsSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
