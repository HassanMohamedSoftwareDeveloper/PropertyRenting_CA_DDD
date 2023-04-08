using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.City;

namespace PropertyRenting.Application.Queries.City.Handlers;

internal sealed class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, ErrorOr<CityDTO>>
{
    private readonly ICityReadRepository _cityReadRepository;

    public GetCityByIdQueryHandler(ICityReadRepository cityReadRepository)
    {
        _cityReadRepository = cityReadRepository;
    }
    public async Task<ErrorOr<CityDTO>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _cityReadRepository.GetByIdAsync<CityDTO>(new GetCityByIdSpecification(request.CityId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
