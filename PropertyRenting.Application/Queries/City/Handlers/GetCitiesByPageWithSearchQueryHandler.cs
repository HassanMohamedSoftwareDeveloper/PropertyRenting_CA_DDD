using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.City;

namespace PropertyRenting.Application.Queries.City.Handlers;

internal sealed class GetCitiesByPageWithSearchQueryHandler : IRequestHandler<GetCitiesByPageWithSearchQuery, ErrorOr<PagedList<CityReadDTO>>>
{
    private readonly ICityReadRepository _cityReadRepository;

    public GetCitiesByPageWithSearchQueryHandler(ICityReadRepository cityReadRepository)
    {
        _cityReadRepository = cityReadRepository;
    }
    public async Task<ErrorOr<PagedList<CityReadDTO>>> Handle(GetCitiesByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _cityReadRepository.GetPageAsync<CityReadDTO>(new GetCitiesByPageWithSearchSpecification(request.SearchValue),
           request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
