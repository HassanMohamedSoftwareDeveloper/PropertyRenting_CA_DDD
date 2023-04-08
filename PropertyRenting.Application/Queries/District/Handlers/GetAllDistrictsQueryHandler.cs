using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.District;

namespace PropertyRenting.Application.Queries.District.Handlers;

internal sealed class GetAllDistrictsQueryHandler : IRequestHandler<GetAllDistrictsQuery, ErrorOr<List<DistrictReadDTO>>>
{
    private readonly IDistrictReadRepository _districtReadRepository;

    public GetAllDistrictsQueryHandler(IDistrictReadRepository districtReadRepository)
    {
        _districtReadRepository = districtReadRepository;
    }
    public async Task<ErrorOr<List<DistrictReadDTO>>> Handle(GetAllDistrictsQuery request, CancellationToken cancellationToken)
    {
        var data = await _districtReadRepository.GetAsync<DistrictReadDTO>(new GetDistrictsSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
