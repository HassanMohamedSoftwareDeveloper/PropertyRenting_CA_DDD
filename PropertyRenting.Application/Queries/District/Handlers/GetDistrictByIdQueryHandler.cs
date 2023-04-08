using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.District;

namespace PropertyRenting.Application.Queries.District.Handlers;

internal sealed class GetDistrictByIdQueryHandler : IRequestHandler<GetDistrictByIdQuery, ErrorOr<DistrictDTO>>
{
    private readonly IDistrictReadRepository _districtReadRepository;

    public GetDistrictByIdQueryHandler(IDistrictReadRepository districtReadRepository)
    {
        _districtReadRepository = districtReadRepository;
    }
    public async Task<ErrorOr<DistrictDTO>> Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _districtReadRepository.GetByIdAsync<DistrictDTO>(new GetDistrictByIdSpecification(request.DistrictId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
