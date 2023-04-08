using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Country;

namespace PropertyRenting.Application.Queries.Country.Handlers;

internal sealed class GetCountriesByPageWithSearchQueryHandler : IRequestHandler<GetCountriesByPageWithSearchQuery, ErrorOr<PagedList<CountryDTO>>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    public GetCountriesByPageWithSearchQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    public async Task<ErrorOr<PagedList<CountryDTO>>> Handle(GetCountriesByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _countryReadRepository.GetPageAsync<CountryDTO>(new GetCountriesByPageWithSearchSpecification(request.SearchValue),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
