using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Building;

namespace PropertyRenting.Application.Queries.Building.Handlers;

internal sealed class GetActiveBuildingsLookupQueryHandler : IRequestHandler<GetActiveBuildingsLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IBuildingReadRepository _buildingReadRepository;

    public GetActiveBuildingsLookupQueryHandler(IBuildingReadRepository buildingReadRepository)
    {
        _buildingReadRepository = buildingReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetActiveBuildingsLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _buildingReadRepository.GetLookupAsync<BaseLookupDTO>(new GetActiveBuildingsLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
