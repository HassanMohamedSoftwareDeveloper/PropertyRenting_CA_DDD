using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.City;

namespace PropertyRenting.Application.Queries.City.Handlers;

internal sealed class GetCitiesLookupQueryHandler : IRequestHandler<GetCitiesLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly ICityReadRepository _cityReadRepository;

    public GetCitiesLookupQueryHandler(ICityReadRepository cityReadRepository)
    {
        _cityReadRepository = cityReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetCitiesLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _cityReadRepository.GetLookupAsync<BaseLookupDTO>(new GetCitiesLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
