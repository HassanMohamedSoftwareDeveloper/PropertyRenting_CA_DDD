using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.District;

namespace PropertyRenting.Application.Queries.District.Handlers;

internal sealed class GetDistrictsLookupByCityIdQueryHandler : IRequestHandler<GetDistrictsLookupByCityIdQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IDistrictReadRepository _districtReadRepository;

    public GetDistrictsLookupByCityIdQueryHandler(IDistrictReadRepository districtReadRepository)
    {
        _districtReadRepository = districtReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetDistrictsLookupByCityIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _districtReadRepository.GetLookupAsync<BaseLookupDTO>(new GetDistrictsLookupByCityIdSpecification(request.CityId), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
