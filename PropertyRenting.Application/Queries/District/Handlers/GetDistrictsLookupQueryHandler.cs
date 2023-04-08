using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.District;

namespace PropertyRenting.Application.Queries.District.Handlers;

internal sealed class GetDistrictsLookupQueryHandler : IRequestHandler<GetDistrictsLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IDistrictReadRepository _districtReadRepository;

    public GetDistrictsLookupQueryHandler(IDistrictReadRepository districtReadRepository)
    {
        _districtReadRepository = districtReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetDistrictsLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _districtReadRepository.GetLookupAsync<BaseLookupDTO>(new GetDistrictsLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
