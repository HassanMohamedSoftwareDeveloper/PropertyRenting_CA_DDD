using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.District;

namespace PropertyRenting.Application.Queries.District.Handlers;

internal sealed class GetDistrictsByPageWithSearchQueryHandler : IRequestHandler<GetDistrictsByPageWithSearchQuery, ErrorOr<PagedList<DistrictReadDTO>>>
{
    private readonly IDistrictReadRepository _districtReadRepository;

    public GetDistrictsByPageWithSearchQueryHandler(IDistrictReadRepository districtReadRepository)
    {
        _districtReadRepository = districtReadRepository;
    }
    public async Task<ErrorOr<PagedList<DistrictReadDTO>>> Handle(GetDistrictsByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _districtReadRepository.GetPageAsync<DistrictReadDTO>(new GetDistrictsByPageWithSearchSpecification(request.SearchValue),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
