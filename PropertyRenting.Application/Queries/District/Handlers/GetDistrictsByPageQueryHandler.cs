using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.District;

namespace PropertyRenting.Application.Queries.District.Handlers;

internal sealed class GetDistrictsByPageQueryHandler : IRequestHandler<GetDistrictsByPageQuery, ErrorOr<PagedList<DistrictReadDTO>>>
{
    private readonly IDistrictReadRepository _districtReadRepository;

    public GetDistrictsByPageQueryHandler(IDistrictReadRepository districtReadRepository)
    {
        _districtReadRepository = districtReadRepository;
    }
    public async Task<ErrorOr<PagedList<DistrictReadDTO>>> Handle(GetDistrictsByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _districtReadRepository.GetPageAsync<DistrictReadDTO>(new GetDistrictsByPageSpecification(), request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
