using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.City;

namespace PropertyRenting.Application.Queries.City.Handlers;

internal sealed class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, ErrorOr<List<CityReadDTO>>>
{
    private readonly ICityReadRepository _cityReadRepository;

    public GetAllCitiesQueryHandler(ICityReadRepository cityReadRepository)
    {
        _cityReadRepository = cityReadRepository;
    }
    public async Task<ErrorOr<List<CityReadDTO>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        var data = await _cityReadRepository.GetAsync<CityReadDTO>(new GetCitiesSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
