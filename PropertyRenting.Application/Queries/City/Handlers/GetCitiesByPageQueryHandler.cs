using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.City;

namespace PropertyRenting.Application.Queries.City.Handlers;

internal sealed class GetCitiesByPageQueryHandler : IRequestHandler<GetCitiesByPageQuery, ErrorOr<PagedList<CityReadDTO>>>
{
    private readonly ICityReadRepository _cityReadRepository;

    public GetCitiesByPageQueryHandler(ICityReadRepository cityReadRepository)
    {
        _cityReadRepository = cityReadRepository;
    }
    public async Task<ErrorOr<PagedList<CityReadDTO>>> Handle(GetCitiesByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _cityReadRepository.GetPageAsync<CityReadDTO>(new GetCitiesByPageSpecification(), request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
